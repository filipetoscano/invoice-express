using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "pay-cancel", Description = "Cancels an invoice payment (and corresponding receipt)" )]
public class InvoicePayCancelCommand
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
    [Option( "-m|--message", CommandOptionType.SingleValue, Description = "Message explaining action" )]
    public string Message { get; set; } = "Cancel payment";


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * 
         */
        var res = await api.InvoicePaymentCancelAsync(
            this.InvoiceType!.Value,
            this.InvoiceId!.Value,
            this.Message );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
