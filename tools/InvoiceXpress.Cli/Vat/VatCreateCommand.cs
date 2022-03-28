using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a VAT rate" )]
public class VatCreateCommand
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
        var res = await api.TaxCreateAsync( vat );
        Console.Write( res.Result!.Id );

        return 0;
    }
}
