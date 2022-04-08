using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

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
    [Argument( 0, "Search query file, in JSON format" )]
    [FileExists]
    public string? SearchQueryFilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        var search = new GuideSearch();

        if ( this.SearchQueryFilePath != null )
        {
            var json = await File.ReadAllTextAsync( this.SearchQueryFilePath );
            search = JsonSerializer.Deserialize<GuideSearch>( json )!;
        }


        /*
         * 
         */
        List<Guide> guides;

        if ( this.FetchAll == false )
        {
            var res = await api.GuideListAsync( search, this.Page, this.PageSize );
            guides = res.Result!;
        }
        else
        {
            var pageIx = 1;
            guides = new List<Guide>();

            while ( true )
            {
                var page = await api.GuideListAsync( search, pageIx, this.PageSize );
                guides.AddRange( page.Result! );

                if ( page.Pagination.PageCount == pageIx )
                    break;

                pageIx++;
            }
        }


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Type", "Doc #", "State", "Client", "Total", "Currency" );

        foreach ( var r in guides.OrderBy( x => x.Id ) )
            table.AddRow( r.Id, r.Type, r.SequenceNumber, r.State, r.Client.Name, r.TotalAmount, r.CurrencyCode );

        table.Write( Format.Minimal );

        return 0;
    }
}
