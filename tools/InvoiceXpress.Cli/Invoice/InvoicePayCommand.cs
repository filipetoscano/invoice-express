using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "pay", Description = "Pays an invoice, in full or partially" )]
public class InvoicePayCommand
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
    [Option( "-i|--input", CommandOptionType.SingleValue, Description = "Payment structure, in JSON file" )]
    [FileExists]
    public string? PaymentFilePath { get; set; }

    /// <summary />
    [Option( "-a|--amount", CommandOptionType.SingleValue, Description = "Payment amount. Default = Full invoice amount" )]
    public decimal? PaymentAmount { get; set; }

    /// <summary />
    [Option( "-m|--method|--by", CommandOptionType.SingleValue, Description = "Payment method" )]
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.DebitCard;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        InvoicePayment payment;

        if ( this.PaymentFilePath != null )
        {
            var json = await File.ReadAllTextAsync( this.PaymentFilePath );
            payment = JsonSerializer.Deserialize<InvoicePayment>( json )!;
        }
        else
        {
            var get = await api.InvoiceGetAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

            if ( get.IsSuccessful == false )
                return console.WriteError( get );

            payment = new InvoicePayment()
            {
                Amount = this.PaymentAmount.HasValue == true ? this.PaymentAmount.Value : get.Result!.TotalAmount,
                Date = DateOnly.FromDateTime( DateTime.Now ),
                PaymentMethod = this.PaymentMethod,
                Remarks = "",
            };
        }


        /*
         * 
         */
        var res = await api.InvoicePaymentAsync(
            this.InvoiceType!.Value,
            this.InvoiceId!.Value,
            payment );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
