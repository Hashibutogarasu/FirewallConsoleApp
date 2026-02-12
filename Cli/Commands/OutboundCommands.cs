using System;
using System.Linq;
using FirewallConsoleApp.Cli.Helpers;

using LibFirewall;
using Shared = global::LibFirewall.Shared;

namespace FirewallConsoleApp.Cli.Commands
{
    public class GetOutboundCommand(GetOutboundOptions options) : IExecutableCommand, IFirewallRequired
    {
        private readonly GetOutboundOptions _options = options;

        public void Execute()
        {
            var rules = Firewall.GetOutboundRules().ToList();
            var json = JsonOutputHelper.Serialize(rules);
            Console.WriteLine(json);
        }
    }

    public class AddOutboundCommand(AddOutboundOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly AddOutboundOptions _options = options;

        public void Execute()
        {
            var rule = new Shared.FirewallOutboundRule
            {
                Name = _options.Name,
                Action = _options.Action,
                Protocol = _options.Protocol,
                LocalPorts = _options.LocalPorts,
                Enabled = true
            };

            Firewall.AddOutboundRule(rule);
            Console.WriteLine("Rule added successfully.");
        }
    }

    public class DeleteOutboundCommand(DeleteOutboundOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly DeleteOutboundOptions _options = options;

        public void Execute()
        {
            Firewall.DeleteRule(_options.Name);
            Console.WriteLine($"Rule '{_options.Name}' deleted successfully.");
        }
    }

    public class UpdateOutboundCommand(UpdateOutboundOptions options) : IExecutableCommand, IAdminRequired, IFirewallRequired
    {
        private readonly UpdateOutboundOptions _options = options;

        public void Execute()
        {

            var rule = new Shared.FirewallOutboundRule
            {
                Name = _options.Name,
                Action = _options.Action,
                Protocol = _options.Protocol,
                LocalPorts = _options.LocalPorts,
                Enabled = true
            };

            Firewall.UpdateOutboundRule(rule);
            Console.WriteLine($"Rule '{_options.Name}' updated successfully.");
        }
    }
}
