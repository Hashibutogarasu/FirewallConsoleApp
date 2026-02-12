using CommandLine;
using FirewallConsoleApp.Cli;
using FirewallConsoleApp.Cli.Commands;

class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<
            ServeOptions,
            GetInboundOptions, AddInboundOptions, DeleteInboundOptions, UpdateInboundOptions,
            GetOutboundOptions, AddOutboundOptions, DeleteOutboundOptions, UpdateOutboundOptions,
            GetConnectionOptions, AddConnectionOptions, DeleteConnectionOptions, UpdateConnectionOptions>(args)
            .WithParsed(options =>
            {
                IExecutableCommand? command = options switch
                {
                    ServeOptions opts => new ServeCommand(opts),
                    UpdateInboundOptions opts => new UpdateInboundCommand(opts),
                    GetInboundOptions opts => new GetInboundCommand(opts),
                    AddInboundOptions opts => new AddInboundCommand(opts),
                    DeleteInboundOptions opts => new DeleteInboundCommand(opts),
                    UpdateOutboundOptions opts => new UpdateOutboundCommand(opts),
                    GetOutboundOptions opts => new GetOutboundCommand(opts),
                    AddOutboundOptions opts => new AddOutboundCommand(opts),
                    DeleteOutboundOptions opts => new DeleteOutboundCommand(opts),
                    UpdateConnectionOptions opts => new UpdateConnectionCommand(opts),
                    GetConnectionOptions opts => new GetConnectionCommand(opts),
                    AddConnectionOptions opts => new AddConnectionCommand(opts),
                    DeleteConnectionOptions opts => new DeleteConnectionCommand(opts),
                    _ => null
                };

                if (command != null)
                {
                    Pipeline.Execute(command);
                }
                else
                {
                    Console.WriteLine("Command implementation not found for selected option.");
                }
            })
            .WithNotParsed(errors =>
            {
            });
    }
}
