using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "list", Description = "Lists invoice" )]
public class InvoiceListCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        await Task.Delay( 0 );

        return 0;
    }
}
