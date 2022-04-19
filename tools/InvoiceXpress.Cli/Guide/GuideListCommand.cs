using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists guides" )]
public class GuideListCommand
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
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        var search = new GuideSearch();

        if ( this.SearchQueryFilePath != null )
        {
            var json = await File.ReadAllTextAsync( this.SearchQueryFilePath );
            search = jss.Deserialize<GuideSearch>( json );
        }


        /*
         * 
         */
        List<Guide> guides;
        Pagination? pagination = null;

        if ( this.FetchAll == false )
        {
            var res = await api.GuideListAsync( search, this.Page, this.PageSize );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            guides = res.Result!;
            pagination = res.Pagination;
        }
        else
        {
            var pageIx = 1;
            guides = new List<Guide>();

            while ( true )
            {
                var res = await api.GuideListAsync( search, pageIx, this.PageSize );

                if ( res.IsSuccessful == false )
                    return console.WriteError( res );

                guides.AddRange( res.Result! );

                if ( res.Pagination!.PageCount == pageIx )
                    break;

                pageIx++;
            }
        }


        /*
         * 
         */
        if ( this.EmitJson == false )
        {
            var table = new ConsoleTable( "Id", "Type", "Doc #", "State", "Client", "Total", "Currency" );

            foreach ( var r in guides.OrderBy( x => x.Id ) )
                table.AddRow( r.Id, r.Type, r.SequenceNumber, r.State, r.Client.Name, r.TotalAmount, r.CurrencyCode );

            table.Write( Format.Minimal );

            if ( pagination?.PageCount > 1 )
                Console.WriteLine( "page {0}/{1} - {2} guides", pagination.Page, pagination.PageCount, pagination.EntryCount );
        }
        else
        {
            var data = guides.OrderBy( x => x.Id ).Select( x => new
            {
                Id = x.Id,
                Type = x.Type,
                DocumentNumber = x.InvertedSequenceNumber ?? null,
                State = x.State,
                Client = x.Client.Name,
                TotalAmount = x.TotalAmount,
                CurrencyCode = x.CurrencyCode,
            } );

            var json = jss.Serialize( data );
            Console.Write( json );
        }

        return 0;
    }
}
