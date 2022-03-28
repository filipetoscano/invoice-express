using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a VAT rate" )]
public class VatUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate, in JSON file" )]
    [Required]
    [FileExists]
    public string FilePath { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath );
        var vat = JsonSerializer.Deserialize<Tax>( json )!;


        /*
         * 
         */
        await api.TaxUpdateAsync( vat );

        return 0;
    }
}
