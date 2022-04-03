using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "estimate", Description = "Estimate operations (quotes, proformas, fee notes)" )]
[Subcommand( typeof( EstimateCreateCommand ) )]
[Subcommand( typeof( EstimateDetailCommand ) )]
[Subcommand( typeof( EstimateEmailCommand ) )]
[Subcommand( typeof( EstimateListCommand ) )]
[Subcommand( typeof( EstimatePdfCommand ) )]
[Subcommand( typeof( EstimateStateChangeCommand ) )]
[Subcommand( typeof( EstimateUpdateCommand ) )]
public class EstimateCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
