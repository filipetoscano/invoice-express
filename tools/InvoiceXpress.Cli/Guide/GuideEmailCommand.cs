using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "email", Description = "Email a guide document" )]
public class GuideEmailCommand
{
    /// <summary />
    [Argument( 0, Description = "Guide type" )]
    [Required]
    public GuideType? GuideType { get; set; }

    /// <summary />
    [Argument( 1, Description = "Guide identifier" )]
    [Required]
    public int? GuideId { get; set; }

    /// <summary />
    [Argument( 2, Description = "Email address" )]
    [Required]
    public string? EmailAddress { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * Fetch the details of the invoice, so that we can generate a more
         * interesting subject / body.
         */
        var get = await api.GuideGetAsync( this.GuideType!.Value, this.GuideId!.Value );


        /*
         * 
         */
        var message = new EmailMessage()
        {
            To = this.EmailAddress!,
            Subject = this.GuideType!.Value + " " + get.Result!.SequenceNumber,
            Body = "(Body)",
            IncludeLogo = false,
            SaveEmailAsDefault = false,
        };


        /*
         * 
         */
        var res = await api.GuideSendByEmailAsync( 
            this.GuideType!.Value, 
            this.GuideId!.Value,
            message );

        return 0;
    }
}
