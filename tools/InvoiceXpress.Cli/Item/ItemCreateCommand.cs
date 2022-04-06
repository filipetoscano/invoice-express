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
    [Required]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var item = JsonSerializer.Deserialize<Item>( json )!;


        /*
         * 
         */
        var res = await api.ItemCreateAsync( item );
        Console.Write( res.Result!.Id );

        return 0;
    }
}
