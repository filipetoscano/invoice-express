using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "export", Description = "Exports SAF-T report for a given month" )]
public class SaftExportCommand
{
    /// <summary />
    [Argument( 0, Description = "Year" )]
    [Required]
    public int Year { get; set; }

    /// <summary />
    [Argument( 1, Description = "Month" )]
    [Required]
    public int Month { get; set; }

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
            return await SaftGenerateAsync( api, console );
        else
            return await SaftDownloadAsync( api, console );
    }


    /// <summary />
    private async Task<int> SaftGenerateAsync( InvoiceXpressClient api, IConsole console )
    {
        string url;

        while ( true )
        {
            var res = await api.SaftExportGenerateAsync( this.Year, this.Month );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            if ( res.StatusCode == HttpStatusCode.OK )
            {
                url = res.Result!;
                break;
            }

            await Task.Delay( 2000 );
        }


        /*
         * 
         */
        Console.WriteLine( url );

        return 0;
    }


    /// <summary />
    private async Task<int> SaftDownloadAsync( InvoiceXpressClient api, IConsole console )
    {
        byte[] bytes;

        while ( true )
        {
            var res = await api.SaftExportTryDocumentAsync( this.Year, this.Month );

            if ( res.IsSuccessful == false )
                return console.WriteError( res );

            if ( res.StatusCode == HttpStatusCode.OK )
            {
                bytes = res.Result!;
                break;
            }

            await Task.Delay( 2000 );
        }


        /*
         * 
         */
        var filename = this.OutputFile ?? $"SAFT-{ this.Year }-{ this.Month }.txt";

        Console.WriteLine( $"Writing to { filename }..." );
        await File.WriteAllBytesAsync( filename, bytes );

        return 0;
    }
}
