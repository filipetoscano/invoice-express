using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an invoice" )]
public class InvoiceUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Invoice record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set invoice identifier, overriding value in JSON file" )]
    public int? InvoiceId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<InvoiceData>( console, this.FilePath, jss, out var invoice ) == false )
            return 599;

        if ( this.InvoiceId.HasValue == true )
            invoice.Id = this.InvoiceId.Value;


        /*
         * 
         */
        var res = await api.InvoiceUpdateAsync( invoice );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
