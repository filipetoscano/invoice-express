using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "estimate", Description = "Estimate operations (list / create / update" )]
[Subcommand( typeof( EstimateCreateCommand ) )]
[Subcommand( typeof( EstimateDetailCommand ) )]
[Subcommand( typeof( EstimateListCommand ) )]
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
