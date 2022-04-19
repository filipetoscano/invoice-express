using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a VAT rate" )]
public class VatCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var vat = jss.Deserialize<VatRate>( json );


        /*
         * 
         */
        var res = await api.VatRateCreateAsync( vat );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.Write( res.Result!.Id );

        return 0;
    }
}
