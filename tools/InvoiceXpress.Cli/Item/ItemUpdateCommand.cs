using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an item record" )]
public class ItemUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Item record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set item identifier, overriding value in JSON file" )]
    public int? ItemId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<Item>( console, this.FilePath, jss, out var item ) == false )
            return 599;

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
