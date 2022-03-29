using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "saft", Description = "SAF-T operations (export)" )]
[Subcommand( typeof( SaftExportCommand ) )]
public class SaftCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
