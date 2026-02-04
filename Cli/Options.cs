using CommandLine;

namespace FirewallConsoleApp.Cli
{
    public abstract class CommonOptions
    {
    }

    [Verb("serve", HelpText = "Start the gRPC server and listen for IPC requests.")]
    public class ServeOptions : CommonOptions
    {
        [Option('p', "port", Default = 5000, HelpText = "Port to listen on.")]
        public int Port { get; set; }
    }

    [Verb("connection-list", HelpText = "List connection security rules.")]
    public class GetConnectionOptions : CommonOptions { }

    [Verb("connection-add", HelpText = "Add a new connection security rule.")]
    public class AddConnectionOptions : CommonOptions
    {
        [Option('n', "name", Required = true, HelpText = "Rule Name")]
        public string Name { get; set; } = "";

        [Option("action", Default = LibFirewall.Shared.RuleAction.Block, HelpText = "Action (not used for connection rules usually, but kept for consistency/extensibility)")]
        public LibFirewall.Shared.RuleAction Action { get; set; }
    }

    [Verb("connection-delete", HelpText = "Delete a connection security rule.")]
    public class DeleteConnectionOptions : CommonOptions
    {
        [Option('n', "name", Required = true, HelpText = "Rule Name")]
        public string Name { get; set; } = "";
    }

    [Verb("connection-update", HelpText = "Update a connection security rule.")]
    public class UpdateConnectionOptions : AddConnectionOptions { }

    [Verb("inbound-list", HelpText = "List inbound firewall rules.")]
    public class GetInboundOptions : CommonOptions { }

    [Verb("inbound-add", HelpText = "Add a new inbound firewall rule.")]
    public class AddInboundOptions : CommonOptions
    {
        [Option('n', "name", Required = true, HelpText = "Rule Name")]
        public string Name { get; set; } = "";

        [Option('p', "protocol", Default = 6, HelpText = "Protocol (6=TCP, 17=UDP)")]
        public int Protocol { get; set; }

        [Option("local-port", HelpText = "Local Ports")]
        public string LocalPorts { get; set; } = "";

        [Option("action", Default = LibFirewall.Shared.RuleAction.Block, HelpText = "Action (Allow/Block)")]
        public LibFirewall.Shared.RuleAction Action { get; set; }
    }

    [Verb("inbound-delete", HelpText = "Delete an inbound firewall rule.")]
    public class DeleteInboundOptions : CommonOptions
    {
        [Option('n', "name", Required = true, HelpText = "Rule Name")]
        public string Name { get; set; } = "";
    }
    [Verb("inbound-update", HelpText = "Update an existing inbound firewall rule.")]
    public class UpdateInboundOptions : AddInboundOptions { }

    [Verb("outbound-list", HelpText = "List outbound firewall rules.")]
    public class GetOutboundOptions : CommonOptions { }

    [Verb("outbound-add", HelpText = "Add a new outbound firewall rule.")]
    public class AddOutboundOptions : CommonOptions
    {
        [Option('n', "name", Required = true, HelpText = "Rule Name")]
        public string Name { get; set; } = "";

        [Option('p', "protocol", Default = 6, HelpText = "Protocol (6=TCP, 17=UDP)")]
        public int Protocol { get; set; }

        [Option("local-port", HelpText = "Local Ports")]
        public string LocalPorts { get; set; } = "";

        [Option("action", Default = LibFirewall.Shared.RuleAction.Block, HelpText = "Action (Allow/Block)")]
        public LibFirewall.Shared.RuleAction Action { get; set; }
    }

    [Verb("outbound-delete", HelpText = "Delete an outbound firewall rule.")]
    public class DeleteOutboundOptions : CommonOptions
    {
        [Option('n', "name", Required = true, HelpText = "Rule Name")]
        public string Name { get; set; } = "";
    }

    [Verb("outbound-update", HelpText = "Update an existing outbound firewall rule.")]
    public class UpdateOutboundOptions : AddOutboundOptions { }
}
