using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "invoice", Description = "Invoice operations (invoice, receipts, debit & credit notes, etc)" )]
[Subcommand( typeof( InvoiceCreateCommand ) )]
[Subcommand( typeof( InvoiceDetailCommand ) )]
[Subcommand( typeof( InvoiceListCommand ) )]
[Subcommand( typeof( InvoiceUpdateCommand ) )]
public class InvoiceCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
