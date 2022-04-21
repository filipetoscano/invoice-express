using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Retrieves an account record" )]
public class AccountDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Account identifier" )]
    [Required]
    public int Identifier { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        var res = await api.AccountGetAsync( this.Identifier );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var json = jss.Serialize( res.Result! );
        Console.WriteLine( json );

        return 0;
    }
}
