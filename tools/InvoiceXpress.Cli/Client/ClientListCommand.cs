using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

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
    [Option( "-a|--all", CommandOptionType.NoValue, Description = "Fetch all records" )]
    public bool FetchAll { get; set; }

    /// <summary />
    [Option( "--json", CommandOptionType.NoValue, Description = "Emit results as JSON" )]
    public bool EmitJson { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * 
         */
        List<Client> clients;
        Pagination? pagination = null;

        if ( this.FetchAll == false )
        {
            var res = await api.ClientListAsync( this.Page, this.PageSize );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            clients = res.Result!;
            pagination = res.Pagination;
        }
        else
        {
            var pageIx = 1;
            clients = new List<Client>();

            while ( true )
            {
                var res = await api.ClientListAsync( pageIx, this.PageSize );

                if ( res.IsSuccessful == false )
                    return console.WriteError( res );

                clients.AddRange( res.Result! );

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
            var table = new ConsoleTable( "Id", "Code", "Name", "Country", "VAT #" );

            foreach ( var r in clients.OrderBy( x => x.Code ) )
                table.AddRow( r.Id, r.Code, r.Name, r.Country, r.TaxNumber );

            table.Write( Format.Minimal );

            if ( pagination?.PageCount > 1 )
                Console.WriteLine( "page {0}/{1} - {2} clients", pagination.Page, pagination.PageCount, pagination.EntryCount );
        }
        else
        {
            var data = clients.OrderBy( x => x.Id ).Select( x => new
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Country = x.Country ?? null,
                TaxNumber = x.TaxNumber ?? null,
            } );

            var json = JsonSerializer.Serialize( data );
            Console.Write( json );
        }

        return 0;
    }
}
