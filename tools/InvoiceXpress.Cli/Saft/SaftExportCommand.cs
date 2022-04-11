using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "export", Description = "Exports SAF-T report for a given month" )]
public class SaftExportCommand
{
    /// <summary />
    [Argument( 0, Description = "Year" )]
    [Required]
    public int Year { get; set; }

    /// <summary />
    [Argument( 1, Description = "Month" )]
    [Required]
    public int Month { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        string url;

        while ( true )
        {
            var res = await api.SaftExportAsync( this.Year, this.Month );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            if ( res.StatusCode == HttpStatusCode.OK )
            {
                url = res.Result!;
                break;
            }

            Console.WriteLine( "Sleeping 2s..." );
            await Task.Delay( 2000 );
        }


        /*
         * 
         */
        Console.WriteLine( url );

        return 0;
    }
}
