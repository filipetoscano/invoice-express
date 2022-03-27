using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "item", Description = "Item operations (list / create / update" )]
[Subcommand( typeof( ItemCreateCommand ) )]
[Subcommand( typeof( ItemDetailCommand ) )]
[Subcommand( typeof( ItemListCommand ) )]
[Subcommand( typeof( ItemUpdateCommand ) )]
public class ItemCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
