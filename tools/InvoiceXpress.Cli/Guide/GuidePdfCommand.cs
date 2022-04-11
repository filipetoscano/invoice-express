using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "pdf", Description = "Generates a PDF document for a given guide" )]
public class GuidePdfCommand
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
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.GuidePdfGenerateAsync( this.GuideType!.Value, this.GuideId!.Value );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Url );

        return 0;
    }
}
