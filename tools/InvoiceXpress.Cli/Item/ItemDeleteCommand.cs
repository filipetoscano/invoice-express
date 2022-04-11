using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "delete", Description = "Deletes an item record" )]
public class ItemDeleteCommand
{
    /// <summary />
    [Argument( 0, Description = "Item identifier" )]
    [Required]
    public int ItemId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.ItemDeleteAsync( this.ItemId );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
