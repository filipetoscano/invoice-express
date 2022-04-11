using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "state", Description = "Changes the state of an invoice" )]
public class InvoiceStateChangeCommand
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
    [Argument( 2, Description = "Action, which will change invoice state" )]
    [Required]
    public InvoiceAction? Action { get; set; }

    /// <summary />
    [Option( "-m|--message", CommandOptionType.SingleValue, Description = "Message explaining state transition" )]
    public string Message { get; set; } = "Change state";


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.InvoiceStateChangeAsync( this.InvoiceType!.Value, this.InvoiceId!.Value, new InvoiceStateChange()
        {
            Action = this.Action!.Value,
            Message = this.Message,
        } );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
