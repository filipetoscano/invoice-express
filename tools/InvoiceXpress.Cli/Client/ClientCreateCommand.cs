using McMaster.Extensions.CommandLineUtils;

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
        /*
         * 
         */
        string json;

        if ( console.IsInputRedirected == true )
            json = await console.In.ReadToEndAsync();
        else if ( this.FilePath != null )
            json = await File.ReadAllTextAsync( this.FilePath! );
        else
            return console.WriteError( "The FilePath field is required, or pipe JSON to stdin" );


        /*
         * 
         */
        var client = jss.Deserialize<Client>( json )!;


        /*
         * 
         */
        var res = await api.ClientCreateAsync( client );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( "ClientId: {0}", res.Result!.Id );

        return 0;
    }
}
