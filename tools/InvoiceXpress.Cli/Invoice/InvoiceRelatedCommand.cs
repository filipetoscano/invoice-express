using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "related", Description = "Lists invoice" )]
public class InvoiceRelatedCommand
{
    /// <summary />
    [Argument( 0, Description = "Invoice type" )]
    [Required]
    public InvoiceType? InvoiceType { get; set; }

    /// <summary />
    [Argument( 1, Description = "Invoice identifier" )]
    [Required]
    public int? InvoiceId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * 
         */
        var res = await api.InvoiceRelatedDocumentsAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Type", "Doc #", "State", "Client", "Total", "Currency", "Foreign" );

        foreach ( var r in res.Result! )
            table.AddRow( r.Id, r.Type, r.SequenceNumber, r.State, r.Client.Name, r.TotalAmount, r.CurrencyCode, "" );

        table.Write( Format.Minimal );

        return 0;
    }
}
