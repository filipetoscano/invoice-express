using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a VAT rate" )]
public class VatUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set VAT rate identifier, overriding value in JSON file" )]
    public int? RateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var vat = jss.Deserialize<VatRate>( json );

        if ( this.RateId.HasValue == true )
            vat.Id = this.RateId.Value;


        /*
         * 
         */
        var res = await api.VatRateUpdateAsync( vat );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
