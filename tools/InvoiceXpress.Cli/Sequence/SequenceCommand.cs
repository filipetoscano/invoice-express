using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "sequence", Description = "Sequence operations" )]
[Subcommand( typeof( SequenceCreateCommand ) )]
[Subcommand( typeof( SequenceDetailCommand ) )]
[Subcommand( typeof( SequenceListCommand ) )]
[Subcommand( typeof( SequenceSetDefaultCommand ) )]
public class SequenceCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
