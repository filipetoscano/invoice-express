using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists invoice" )]
public class InvoiceListCommand
{
    /// <summary />
    [Option( "-p|--page", CommandOptionType.SingleValue, Description = "Page of 'size' records to retrieve" )]
    public int Page { get; set; } = 1;

    /// <summary />
    [Option( "-s|--page-size", CommandOptionType.SingleValue, Description = "Page size" )]
    public int PageSize { get; set; } = 20;

    /// <summary />
    [Option( "-a|--all", CommandOptionType.NoValue, Description = "Fetch all records" )]
    public bool FetchAll { get; set; }

    /// <summary />
    [Option( "--json", CommandOptionType.NoValue, Description = "Emit results as JSON" )]
    public bool EmitJson { get; set; }

    /// <summary />
    [Argument( 0, "Search query file, in JSON format" )]
    [FileExists]
    public string? SearchQueryFilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        var search = new InvoiceSearch();

        if ( this.SearchQueryFilePath != null )
        {
            var json = await File.ReadAllTextAsync( this.SearchQueryFilePath );
            search = JsonSerializer.Deserialize<InvoiceSearch>( json )!;
        }


        /*
         * 
         */
        List<Invoice> invoices;

        if ( this.FetchAll == false )
        {
            var res = await api.InvoiceListAsync( search, this.Page, this.PageSize );
            invoices = res.Result!;
        }
        else
        {
            var pageIx = 1;
            invoices = new List<Invoice>();

            while ( true )
            {
                var page = await api.InvoiceListAsync( search, pageIx, this.PageSize );
                invoices.AddRange( page.Result! );

                if ( page.Pagination.PageCount == pageIx )
                    break;

                pageIx++;
            }
        }


        /*
         * 
         */
        if ( this.EmitJson == false )
        {
            var table = new ConsoleTable( "Id", "Type", "Doc #", "State", "Client", "Total", "Currency", "Foreign" );

            foreach ( var r in invoices.OrderBy( x => x.Id ) )
                table.AddRow( r.Id, r.Type, r.DocumentNumber(), r.State, r.Client.Name, r.TotalAmount, r.CurrencyCode, r.ForeignCurrency?.CurrencyCode );

            table.Write( Format.Minimal );
        }
        else
        {
            var data = invoices.OrderBy( x => x.Id ).Select( x => new
            {
                Id = x.Id,
                Type = x.Type,
                DocumentNumber = x.DocumentNumber(),
                State = x.State,
                Client = x.Client.Name,
                TotalAmount = x.TotalAmount,
                CurrencyCode = x.CurrencyCode,
                ForeignCurrency = x.ForeignCurrency?.CurrencyCode,
            } );

            var json = JsonSerializer.Serialize( data );
            Console.Write( json );
        }

        return 0;
    }
}
