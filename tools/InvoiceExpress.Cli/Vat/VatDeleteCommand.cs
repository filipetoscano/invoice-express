using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "delete", Description = "Deletes a VAT rate" )]
public class VatDeleteCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate identifier" )]
    [Required]
    public int RateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        var res = await api.TaxDeleteAsync( this.RateId );

        return 0;
    }
}
