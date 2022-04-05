using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "guide", Description = "Guide operations (delivery, shipping and return delivery notes)" )]
[Subcommand( typeof( GuideCreateCommand ) )]
[Subcommand( typeof( GuideDetailCommand ) )]
[Subcommand( typeof( GuideListCommand ) )]
public class GuideCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
