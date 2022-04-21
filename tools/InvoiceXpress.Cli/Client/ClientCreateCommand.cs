using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a client record" )]
public class ClientCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Client record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<Client>( console, this.FilePath, jss, out var client ) == false )
            return 599;


        /*
         * 
         */
        var res = await api.ClientCreateAsync( client );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
