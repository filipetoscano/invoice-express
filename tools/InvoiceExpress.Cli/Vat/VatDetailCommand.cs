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
    public string Identifier { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        var id = int.Parse( this.Identifier );
        var res = await api.TaxGetAsync( id );


        /*
         * 
         */
        var json = JsonSerializer.Serialize( res.Result!, new JsonSerializerOptions() { WriteIndented = true } );
        Console.WriteLine( json );

        return 0;
    }
}
