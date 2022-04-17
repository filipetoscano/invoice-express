using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "item", Description = "Item operations" )]
[Subcommand( typeof( ItemCreateCommand ) )]
[Subcommand( typeof( ItemDeleteCommand ) )]
[Subcommand( typeof( ItemDetailCommand ) )]
[Subcommand( typeof( ItemListCommand ) )]
[Subcommand( typeof( ItemRandomCommand ) )]
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
