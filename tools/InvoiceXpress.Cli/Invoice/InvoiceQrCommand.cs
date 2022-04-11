using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "qr", Description = "Retrieves QrCode associated with finalized invoice" )]
public class InvoiceQrCommand
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
    [Option( "-u|--url", CommandOptionType.NoValue, Description = "Emit URL to console, don't download image" )]
    public bool UrlOnly { get; set; } = false;

    /// <summary />
    [Option( "-o|--output-file", CommandOptionType.SingleValue, Description = "Name of file to write to" )]
    public string? OutputFile { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        if ( this.UrlOnly == true )
        {
            var res = await api.InvoiceQrCodeUrlAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            Console.WriteLine( res.Result );
        }
        else
        {
            var res = await api.InvoiceQrCodeImageAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            var filename = this.OutputFile ?? $"{ this.InvoiceType!.Value}-{ this.InvoiceId!.Value }.png";

            Console.WriteLine( $"Writing to { filename }..." );
            await File.WriteAllBytesAsync( filename, res.Result! );
        }

        return 0;
    }
}
