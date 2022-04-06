using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "guide", Description = "Guide operations (delivery, shipping and return delivery notes)" )]
[Subcommand( typeof( GuideCreateCommand ) )]
[Subcommand( typeof( GuideDetailCommand ) )]
[Subcommand( typeof( GuideEmailCommand ) )]
[Subcommand( typeof( GuideListCommand ) )]
[Subcommand( typeof( GuidePdfCommand ) )]
[Subcommand( typeof( GuideQrCommand ) )]
[Subcommand( typeof( GuideStateChangeCommand ) )]
[Subcommand( typeof( GuideUpdateCommand ) )]
public class GuideCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
