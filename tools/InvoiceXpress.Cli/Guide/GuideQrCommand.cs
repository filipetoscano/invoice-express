using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "qr", Description = "Retrieves QrCode associated with finalized guide" )]
public class GuideQrCommand
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
    [Option( "-u|--url", CommandOptionType.NoValue, Description = "Emit URL to console, don't download image" )]
    public bool UrlOnly { get; set; } = false;

    /// <summary />
    [Option( "-o|--output-file", CommandOptionType.SingleValue, Description = "Name of file to write to" )]
    public string? OutputFile { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        if ( this.UrlOnly == true )
        {
            var res = await api.GuideQrCodeUrlAsync( this.GuideType!.Value, this.GuideId!.Value );
            Console.WriteLine( res.Result );
        }
        else
        {
            var res = await api.GuideQrCodeImageAsync( this.GuideType!.Value, this.GuideId!.Value );
            var filename = this.OutputFile ?? $"{ this.GuideType!.Value}-{ this.GuideId!.Value }.png";

            Console.WriteLine( $"Writing to { filename }..." );
            await File.WriteAllBytesAsync( filename, res.Result! );
        }

        return 0;
    }
}
