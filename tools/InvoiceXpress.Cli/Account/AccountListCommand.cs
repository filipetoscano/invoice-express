using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists accounts associated with API key" )]
public class AccountListCommand
{
    /// <summary />
    [Option( "--json", CommandOptionType.NoValue, Description = "Emit results as JSON" )]
    public bool EmitJson { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * 
         */
        var res = await api.AccountListAsync();

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        var accounts = res.Result!;


        /*
         * 
         */
        if ( this.EmitJson == false )
        {
            var table = new ConsoleTable( "Id","Name", "Country", "VAT #" );

            foreach ( var r in accounts.OrderBy( x => x.Name ) )
                table.AddRow( r.Id, r.Name, r.Country, r.TaxNumber );

            table.Write( Format.Minimal );
        }
        else
        {
            var data = accounts.OrderBy( x => x.Id ).Select( x => new
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country ?? null,
                TaxNumber = x.TaxNumber ?? null,
            } );

            var json = jss.Serialize( data );
            Console.Write( json );
        }

        return 0;
    }
}
