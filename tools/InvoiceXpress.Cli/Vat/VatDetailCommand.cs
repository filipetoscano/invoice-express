using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "get", Description = "Gets a VAT rate" )]
public class VatDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate identifier" )]
    [Required]
    public int RateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        var res = await api.TaxGetAsync( this.RateId );


        /*
         * 
         */
        var json = JsonSerializer.Serialize( res.Result!, new JsonSerializerOptions() { WriteIndented = true } );
        Console.WriteLine( json );

        return 0;
    }
}
