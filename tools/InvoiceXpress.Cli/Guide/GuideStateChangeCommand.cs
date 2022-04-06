using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "state", Description = "Changes the state of a guide" )]
public class GuideStateChangeCommand
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
    [Argument( 2, Description = "Action, which will change guide state" )]
    [Required]
    public GuideAction? Action { get; set; }

    /// <summary />
    [Option( "-m|--message", CommandOptionType.SingleValue, Description = "Message explaining state transition" )]
    public string Message { get; set; } = "Change state";


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        Console.WriteLine( "Change state on {0}/{1}", this.GuideType!.Value, this.GuideId!.Value );

        var res = await api.GuideStateChangeAsync( this.GuideType!.Value, this.GuideId!.Value, new GuideStateChange()
        {
            Action = this.Action!.Value,
            Message = this.Message,
        } );

        return 0;
    }
}
