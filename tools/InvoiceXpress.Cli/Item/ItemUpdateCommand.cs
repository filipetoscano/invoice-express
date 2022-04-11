using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an item record" )]
public class ItemUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Item record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set item identifier, overriding value in JSON file" )]
    public int? ItemId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var item = JsonSerializer.Deserialize<Item>( json )!;

        if ( this.ItemId.HasValue == true )
            item.Id = this.ItemId.Value;


        /*
         * 
         */
        var res = await api.ItemUpdateAsync( item );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
