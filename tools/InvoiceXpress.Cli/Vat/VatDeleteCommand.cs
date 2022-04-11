using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "delete", Description = "Deletes a VAT rate" )]
public class VatDeleteCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate identifier" )]
    [Required]
    public int RateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.VatRateDeleteAsync( this.RateId );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
