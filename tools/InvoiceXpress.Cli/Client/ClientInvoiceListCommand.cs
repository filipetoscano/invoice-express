using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "invoices", Description = "Retrieves list of invoices" )]
public class ClientInvoiceListCommand
{
    /// <summary />
    [Argument( 0, Description = "Client identifier" )]
    [Required]
    public string Identifier { get; set; } = default!;

    /// <summary />
    [Option( "--code", CommandOptionType.NoValue, Description = "Identifier is the code parameter" )]
    public bool IsCode { get; set; } = false;

    /// <summary />
    [Option( "-q|--query", CommandOptionType.SingleValue, Description = "Query, in JSON file" )]
    [FileExists]
    public string? QueryFile { get; set; } = default!;

    /// <summary />
    [Option( "-p|--page", CommandOptionType.SingleValue, Description = "Page of 'size' records to retrieve" )]
    public int Page { get; set; } = 1;

    /// <summary />
    [Option( "-s|--page-size", CommandOptionType.SingleValue, Description = "Page size" )]
    public int PageSize { get; set; } = 20;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * 
         */
        Client client;

        if ( this.IsCode == true )
        {
            var res = await api.ClientGetByCodeAsync( this.Identifier );
            
            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            client = res!.Result!;
        }
        else
        {
            var id = int.Parse( this.Identifier );
            var res = await api.ClientGetAsync( id );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            client = res!.Result!;
        }


        /*
         * 
         */
        ClientInvoiceSearch search;
        
        if ( this.QueryFile != null )
        {
            var json = await File.ReadAllTextAsync( this.QueryFile );
            search = jss.Deserialize<ClientInvoiceSearch>( json );
        }
        else
        {
            // Use defaults!
            search = new ClientInvoiceSearch();
        }


        /*
         * 
         */
        var inv = await api.ClientInvoiceListAsync( client.Id!.Value, search, this.Page, this.PageSize );

        if ( inv.IsSuccessful == false )
            return console.WriteError( inv );


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Type", "Doc #", "State", "Client", "Total", "Currency", "Foreign" );

        foreach ( var r in inv.Result! )
            table.AddRow( r.Id, r.Type, r.DocumentNumber(), r.State, r.Client.Name, r.TotalAmount, r.CurrencyCode, r.ForeignCurrency?.CurrencyCode );

        table.Write( Format.Minimal );

        return 0;
    }
}
