using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "email", Description = "Email an invoice" )]
public class InvoiceEmailCommand
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
    [Argument( 2, Description = "Email address" )]
    [Required]
    public string? EmailAddress { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * Fetch the details of the invoice, so that we can generate a more
         * interesting subject / body.
         */
        var get = await api.InvoiceGetAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

        if ( get.IsSuccessful == false )
            return console.WriteError( get );


        /*
         * 
         */
        var message = new EmailMessage()
        {
            To = this.EmailAddress!,
            Subject = this.InvoiceType!.Value + " " + get.Result!.SequenceNumber,
            Body = "(Body)",
            IncludeLogo = false,
            SaveEmailAsDefault = false,
        };


        /*
         * 
         */
        var res = await api.InvoiceSendByEmailAsync( 
            this.InvoiceType!.Value, 
            this.InvoiceId!.Value,
            message );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
