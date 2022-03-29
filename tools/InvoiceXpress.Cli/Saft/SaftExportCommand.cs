using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

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
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        while ( true )
        {
            var res = await api.SaftExportAsync( this.Year, this.Month );

            if ( res.Result != null )
                break;

            Console.WriteLine( "Sleeping 2s..." );
            await Task.Delay( 2000 );
        }

        return 0;
    }
}
