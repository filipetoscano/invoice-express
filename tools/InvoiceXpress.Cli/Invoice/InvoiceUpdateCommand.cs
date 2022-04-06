using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an invoice" )]
public class InvoiceUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Invoice record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set invoice identifier, overriding value in JSON file" )]
    public int? InvoiceId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var invoice = JsonSerializer.Deserialize<InvoiceData>( json )!;

        if ( this.InvoiceId.HasValue == true )
            invoice.Id = this.InvoiceId.Value;


        /*
         * 
         */
        var res = await api.InvoiceUpdateAsync( invoice );

        return 0;
    }
}
