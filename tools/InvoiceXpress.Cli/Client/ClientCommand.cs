using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "client", Description = "Client operations (list / create / update" )]
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
