using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Gets an estimate" )]
public class EstimateDetailCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        await Task.Delay( 0 );

        return 0;
    }
}
