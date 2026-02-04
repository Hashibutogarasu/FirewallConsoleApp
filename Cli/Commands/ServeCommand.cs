
using LibFirewall;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FirewallConsoleApp.Cli.Commands
{
    public class ServeCommand(ServeOptions options) : IExecutableCommand, IFirewallRequired
    {
        private readonly ServeOptions _options = options;

        public void Execute()
        {
            Console.WriteLine("Firewall Library Initialized (via Pipeline).");

            var builder = WebApplication.CreateBuilder([]);

            builder.Services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
            });
            builder.Services.AddMagicOnion();

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenLocalhost(_options.Port, o => o.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
            });

            var app = builder.Build();

            app.MapMagicOnionService();

            Console.WriteLine($"Starting Firewall Console App Server on localhost:{_options.Port}...");
            app.Run();
        }
    }
}
