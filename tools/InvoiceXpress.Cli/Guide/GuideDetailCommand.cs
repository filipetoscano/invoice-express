using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Retrieves a guide record" )]
public class GuideDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Guide type" )]
    [Required]
    public GuideType? GuideType { get; set; }

    /// <summary />
    [Argument( 1, Description = "Estimate identifier" )]
    [Required]
    public int? EstimateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.GuideGetAsync( this.GuideType!.Value, this.EstimateId!.Value );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var json = JsonSerializer.Serialize( res.Result!, new JsonSerializerOptions() { WriteIndented = true } );
        Console.WriteLine( json );

        return 0;
    }
}
