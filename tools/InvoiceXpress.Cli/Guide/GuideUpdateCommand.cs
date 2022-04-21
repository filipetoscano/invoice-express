using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a guide" )]
public class GuideUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Guide record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set guide identifier, overriding value in JSON file" )]
    public int? GuideId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<GuideData>( console, this.FilePath, jss, out var guide ) == false )
            return 599;

        if ( this.GuideId.HasValue == true )
            guide.Id = this.GuideId.Value;


        /*
         * 
         */
        var res = await api.GuideUpdateAsync( guide );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
