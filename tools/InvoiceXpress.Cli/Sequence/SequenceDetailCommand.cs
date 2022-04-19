using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Gets a sequence record" )]
public class SequenceDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Sequence identifier" )]
    [Required]
    public int SequenceId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        var res = await api.SequenceGetAsync( this.SequenceId );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var json = jss.Serialize( res.Result! );
        console.WriteLine( json );

        return 0;
    }
}
