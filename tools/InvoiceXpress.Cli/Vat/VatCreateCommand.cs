using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a VAT rate" )]
public class VatCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "VAT rate, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<VatRate>( console, this.FilePath, jss, out var vat ) == false )
            return 599;


        /*
         * 
         */
        var res = await api.VatRateCreateAsync( vat );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
