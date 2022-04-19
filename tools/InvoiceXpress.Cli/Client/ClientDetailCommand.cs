using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Retrieves a client record" )]
public class ClientDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Client identifier" )]
    [Required]
    public string Identifier { get; set; } = default!;

    /// <summary />
    [Option( "--code", CommandOptionType.NoValue, Description = "Identifier is the client code, rather than numerical id" )]
    public bool IsCode { get; set; } = false;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
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
        var json = jss.Serialize( client );
        Console.WriteLine( json );

        return 0;
    }
}
