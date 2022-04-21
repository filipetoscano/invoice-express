using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a guide record" )]
public class GuideCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Client record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<GuideData>( console, this.FilePath, jss, out var guide ) == false )
            return 599;


        /*
         * 
         */
        var res = await api.GuideCreateAsync( guide );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
