using System.Security.Principal;

namespace FirewallConsoleApp.Cli
{
    public interface ICommand
    {
    }

    public interface IExecutableCommand
    {
        void Execute();
    }

    public interface IAdminRequired
    {
    }

    public interface IFirewallRequired
    {
    }

    public static class Pipeline
    {
        public static void Execute(object options)
        {
            if (options is IExecutableCommand command)
            {
                if (command is IAdminRequired && !IsAdministrator())
                {
                    Console.Error.WriteLine("Error: This command requires Administrator privileges.");
                    Environment.Exit(2);
                }

                if (command is IFirewallRequired)
                {
                    try
                    {
                        Helpers.FirewallHelper.EnsureInitialized();
                    }
                    catch (global::FirewallConsoleApp.API.Exceptions.FirewallInitializationException)
                    {
                        Console.Error.WriteLine("Error: Failed to initialize firewall library.");
                        Environment.Exit(1);
                    }
                }

                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error executing command: {ex.Message}");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.Error.WriteLine("Error: Command implementation not found.");
            }
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
