using System;
using System.Linq;
using FirewallConsoleApp.Cli.Helpers;

using LibFirewall;
using Shared = global::LibFirewall.Shared;

namespace FirewallConsoleApp.Cli.Commands
{
    public class GetConnectionCommand(GetConnectionOptions options) : IExecutableCommand, IFirewallRequired
    {
        private readonly GetConnectionOptions _options = options;

        public void Execute()
        {
            var rules = Firewall.GetConnectionRules().ToList();
            var json = JsonOutputHelper.Serialize(rules);
            Console.WriteLine(json);
        }
    }

    public class AddConnectionCommand(AddConnectionOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly AddConnectionOptions _options = options;

        public void Execute()
        {
            var rule = new Shared.FirewallConnectionRule
            {
                Name = _options.Name,
                Enabled = true
            };

            Firewall.AddConnectionRule(rule);
            Console.WriteLine("Connection rule added successfully.");
        }
    }

    public class DeleteConnectionCommand(DeleteConnectionOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly DeleteConnectionOptions _options = options;

        public void Execute()
        {
            Firewall.DeleteConnectionRule(_options.Name);
            Console.WriteLine($"Connection rule '{_options.Name}' deleted successfully.");
        }
    }

    public class UpdateConnectionCommand(UpdateConnectionOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly UpdateConnectionOptions _options = options;

        public void Execute()
        {
            var rule = new Shared.FirewallConnectionRule
            {
                Name = _options.Name,
                Enabled = true
            };

            Firewall.UpdateConnectionRule(rule);
            Console.WriteLine($"Connection rule '{_options.Name}' updated successfully.");
        }
    }
}
