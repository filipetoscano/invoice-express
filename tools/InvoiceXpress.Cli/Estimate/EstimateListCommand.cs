using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists estimates" )]
public class EstimateListCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        await Task.Delay( 0 );

        return 0;
    }
}
