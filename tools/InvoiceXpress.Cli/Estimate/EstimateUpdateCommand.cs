using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an estimate" )]
public class EstimateUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Estimate record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set estimate identifier, overriding value in JSON file" )]
    public int? EstimateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<EstimateData>( console, this.FilePath, jss, out var estimate ) == false )
            return 599;

        if ( this.EstimateId.HasValue == true )
            estimate.Id = this.EstimateId.Value;


        /*
         * 
         */
        var res = await api.EstimateUpdateAsync( estimate );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
