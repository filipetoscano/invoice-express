using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an estimate" )]
public class EstimateUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Estimate record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set estimate identifier, overriding value in JSON file" )]
    public int? EstimateId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var estimate = JsonSerializer.Deserialize<EstimateData>( json )!;

        if ( this.EstimateId.HasValue == true )
            estimate.Id = this.EstimateId.Value;


        /*
         * 
         */
        var res = await api.EstimateUpdateAsync( estimate );

        return 0;
    }
}
