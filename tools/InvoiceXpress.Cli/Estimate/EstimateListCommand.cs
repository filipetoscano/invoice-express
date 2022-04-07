﻿using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists estimates" )]
public class EstimateListCommand
{
    /// <summary />
    [Option( "-p|--page", CommandOptionType.SingleValue, Description = "Page of 'size' records to retrieve" )]
    public int Page { get; set; } = 1;

    /// <summary />
    [Option( "-s|--page-size", CommandOptionType.SingleValue, Description = "Page size" )]
    public int PageSize { get; set; } = 20;

    /// <summary />
    [Argument( 0, "Search query file, in JSON format" )]
    [FileExists]
    public string? SearchQueryFilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        var search = new EstimateSearch();

        if ( this.SearchQueryFilePath != null )
        {
            var json = await File.ReadAllTextAsync( this.SearchQueryFilePath );
            search = JsonSerializer.Deserialize<EstimateSearch>( json )!;
        }


        /*
         * 
         */
        var res = await api.EstimateListAsync( search, this.Page, this.PageSize );


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Type", "Doc #", "State", "Client", "Total", "Currency", "Foreign" );

        foreach ( var r in res.Result! )
            table.AddRow( r.Id, r.Type, r.SequenceNumber, r.State, r.Client.Name, r.TotalAmount, r.CurrencyCode, r.ForeignCurrency != null ? r.ForeignCurrency.CurrencyCode : "" );

        table.Write( Format.Minimal );

        return 0;
    }
}
