using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "list", Description = "Lists items" )]
public class ItemListCommand
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
        var res = await api.ItemListAsync( Page, PageSize );


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Code", "Description", "Unit price", "Unit", "VAT" );

        foreach ( var r in res.Result!.OrderBy( x => x.Code ) )
            table.AddRow( r.Id, r.Code, r.Description, r.UnitPrice, r.Unit, r.Tax?.Value );

        table.Write( Format.Minimal );

        return 0;
    }
}
