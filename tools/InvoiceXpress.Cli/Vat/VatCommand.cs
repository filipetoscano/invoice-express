using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "vat", Description = "VAT rate operations (list / create / update" )]
[Subcommand( typeof( VatCreateCommand ) )]
[Subcommand( typeof( VatDeleteCommand ) )]
[Subcommand( typeof( VatDetailCommand ) )]
[Subcommand( typeof( VatListCommand ) )]
[Subcommand( typeof( VatUpdateCommand ) )]
public class VatCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
