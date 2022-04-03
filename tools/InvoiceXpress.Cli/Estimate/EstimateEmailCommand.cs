using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "email", Description = "Email an estimate" )]
public class EstimateEmailCommand
{
    /// <summary />
    [Argument( 0, Description = "Estimate type" )]
    [Required]
    public EstimateType? EstimateType { get; set; }

    /// <summary />
    [Argument( 1, Description = "Estimate identifier" )]
    [Required]
    public int? EstimateId { get; set; }

    /// <summary />
    [Argument( 2, Description = "Email address" )]
    [Required]
    public string? EmailAddress { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * Fetch the details of the estimate, so that we can generate a more
         * interesting subject / body.
         */
        var get = await api.EstimateGetAsync( this.EstimateType!.Value, this.EstimateId!.Value );


        /*
         * 
         */
        var message = new EmailMessage()
        {
            To = this.EmailAddress!,
            Subject = this.EstimateType!.Value + " " + get.Result!.SequenceNumber,
            Body = "(Body)",
            IncludeLogo = false,
            SaveEmailAsDefault = false,
        };


        /*
         * 
         */
        var res = await api.EstimateSendByEmailAsync( 
            this.EstimateType!.Value, 
            this.EstimateId!.Value,
            message );

        return 0;
    }
}
