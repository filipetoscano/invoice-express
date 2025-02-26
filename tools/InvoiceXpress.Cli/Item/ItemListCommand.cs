﻿using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists items" )]
public class ItemListCommand
{
    /// <summary />
    [Option( "-p|--page", CommandOptionType.SingleValue, Description = "Page of 'size' records to retrieve" )]
    public int Page { get; set; } = 1;

    /// <summary />
    [Option( "-s|--page-size", CommandOptionType.SingleValue, Description = "Page size" )]
    public int PageSize { get; set; } = 20;

    /// <summary />
    [Option( "-a|--all", CommandOptionType.NoValue, Description = "Fetch all records" )]
    public bool FetchAll { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        List<Item> items;

        if ( this.FetchAll == false )
        {
            var res = await api.ItemListAsync( this.Page, this.PageSize );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            items = res.Result!;
        }
        else
        {
            var pageIx = 1;
            items = new List<Item>();

            while ( true )
            {
                var res = await api.ItemListAsync( pageIx, this.PageSize );

                if ( res.IsSuccessful == false )
                    return console.WriteError( res );

                items.AddRange( res.Result! );

                if ( res.Pagination!.PageCount == pageIx )
                    break;

                pageIx++;
            }
        }


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Code", "Description", "Unit price", "Unit", "VAT" );

        foreach ( var r in items.OrderBy( x => x.Code ) )
            table.AddRow( r.Id, r.Code, r.Description, r.UnitPrice, r.Unit, r.VatRate?.Value );

        table.Write( Format.Minimal );

        return 0;
    }
}
