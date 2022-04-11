using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

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
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.ClientListAsync( this.Page, this.PageSize );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Name", "Value", "Country", "VAT #" );

        foreach ( var r in res.Result! )
            table.AddRow( r.Id, r.Code, r.Name, r.Country, r.TaxNumber );

        table.Write( Format.Minimal );


        if ( res.Pagination!.PageCount > 1 )
        {
            var p = res.Pagination!;
            Console.WriteLine( "Page {0}/{1} - Total {2}", p.Page, p.PageCount, p.EntryCount );
        }

        return 0;
    }
}
