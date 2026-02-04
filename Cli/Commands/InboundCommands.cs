using System;
using System.Linq;
using FirewallConsoleApp.Cli.Helpers;

using LibFirewall;
using Shared = global::LibFirewall.Shared;

namespace FirewallConsoleApp.Cli.Commands
{
    public class GetInboundCommand(GetInboundOptions options) : IExecutableCommand, IFirewallRequired
    {
        private readonly GetInboundOptions _options = options;

        public void Execute()
        {
            var rules = Firewall.GetInboundRules().ToList();
            var json = JsonOutputHelper.Serialize(rules);
            Console.WriteLine(json);
        }
    }

    public class AddInboundCommand(AddInboundOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly AddInboundOptions _options = options;

        public void Execute()
        {
            var rule = new Shared.FirewallInboundRule
            {
                Name = _options.Name,
                Action = _options.Action,
                Protocol = _options.Protocol,
                LocalPorts = _options.LocalPorts,
                Enabled = true
            };

            Firewall.AddInboundRule(rule);
            Console.WriteLine("Rule added successfully.");
        }
    }

    public class DeleteInboundCommand(DeleteInboundOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly DeleteInboundOptions _options = options;

        public void Execute()
        {
            Firewall.DeleteRule(_options.Name);
            Console.WriteLine($"Rule '{_options.Name}' deleted successfully.");
        }
    }

    public class UpdateInboundCommand(UpdateInboundOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly UpdateInboundOptions _options = options;

        public void Execute()
        {

            var rule = new Shared.FirewallInboundRule
            {
                Name = _options.Name,
                Action = _options.Action,
                Protocol = _options.Protocol,
                LocalPorts = _options.LocalPorts,
                Enabled = true
            };

            Firewall.UpdateInboundRule(rule);
            Console.WriteLine($"Rule '{_options.Name}' updated successfully.");
        }
    }
}
