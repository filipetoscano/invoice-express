using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create an invoice" )]
public class InvoiceCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Invoice record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<InvoiceData>( console, this.FilePath, jss, out var invoice ) == false )
            return 599;


        /*
         * 
         */
        var res = await api.InvoiceCreateAsync( invoice );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
