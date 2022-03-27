using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a VAT rate" )]
public class VatUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate, in JSON file" )]
    [Required]
    [FileExists]
    public string File { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        await Task.Delay( 0 );

        return 0;
    }
}
