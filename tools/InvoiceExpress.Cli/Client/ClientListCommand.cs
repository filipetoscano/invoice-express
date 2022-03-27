using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "list", Description = "Lists client records" )]
public class ClientListCommand
{
    /// <summary />
    [Option( "-p|--page", CommandOptionType.SingleValue, Description = "Page of 'size' records to retrieve" )]
    public int Page { get; set; } = 1;

    /// <summary />
    [Option( "-s|--page-size", CommandOptionType.SingleValue, Description = "Page size" )]
    public int PageSize { get; set; } = 20;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        var res = await api.ClientListAsync( this.Page, this.PageSize );

        foreach ( var client in res!.Result! )
        {
            Console.WriteLine( "{0} {1} {2} {3} {4}", client.Id, client.Code, client.Name, client.Country, client.TaxNumber );
        }

        return 0;
    }
}
