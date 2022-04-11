using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a guide" )]
public class GuideUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Guide record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set guide identifier, overriding value in JSON file" )]
    public int? GuideId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var guide = JsonSerializer.Deserialize<GuideData>( json )!;

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
