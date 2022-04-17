using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "pdf", Description = "Generates a PDF document for a given invoice" )]
public class InvoicePdfCommand
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
    [Option( "-u|--url", CommandOptionType.NoValue, Description = "Emit URL to console, don't download PDF document" )]
    public bool UrlOnly { get; set; } = false;

    /// <summary />
    [Option( "-o|--output-file", CommandOptionType.SingleValue, Description = "Name of file to write to" )]
    public string? OutputFile { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        if ( this.UrlOnly == true )
            return await PdfGenerateAsync( api, console );
        else
            return await PdfDownloadAsync( api, console );
    }


    /// <summary />
    private async Task<int> PdfGenerateAsync( InvoiceXpressClient api, IConsole console )
    {
        string url;

        while ( true )
        {
            var res = await api.InvoicePdfGenerateAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            if ( res.StatusCode == HttpStatusCode.OK )
            {
                url = res.Result!.Url;
                break;
            }

            await Task.Delay( 1000 );
        }

        Console.WriteLine( url );
        return 0;
    }


    /// <summary />
    private async Task<int> PdfDownloadAsync( InvoiceXpressClient api, IConsole console )
    {
        byte[] bytes;

        while ( true )
        {
            var res = await api.InvoicePdfTryDownloadAsync( this.InvoiceType!.Value, this.InvoiceId!.Value );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            if ( res.StatusCode == HttpStatusCode.OK )
            {
                bytes = res.Result!;
                break;
            }

            await Task.Delay( 1000 );
        }


        /*
         * 
         */
        var filename = this.OutputFile ?? $"{ this.InvoiceType!.Value }-{ this.InvoiceId!.Value }.pdf";

        Console.WriteLine( $"Writing to { filename }..." );
        await File.WriteAllBytesAsync( filename, bytes );

        return 0;
    }
}
