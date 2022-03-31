using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "client", Description = "Client/customer operations" )]
[Subcommand( typeof( ClientCreateCommand ) )]
[Subcommand( typeof( ClientDetailCommand ) )]
[Subcommand( typeof( ClientListCommand ) )]
[Subcommand( typeof( ClientUpdateCommand ) )]
public class ClientCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
