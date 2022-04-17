using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create an item" )]
public class ItemCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Item record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
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
        var item = JsonSerializer.Deserialize<Item>( json )!;


        /*
         * 
         */
        var res = await api.ItemCreateAsync( item );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.Write( res.Result!.Id );

        return 0;
    }
}
