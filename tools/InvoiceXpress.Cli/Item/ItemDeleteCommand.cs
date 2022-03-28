﻿using McMaster.Extensions.CommandLineUtils;
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
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        var res = await api.ItemDeleteAsync( this.ItemId );

        return 0;
    }
}
