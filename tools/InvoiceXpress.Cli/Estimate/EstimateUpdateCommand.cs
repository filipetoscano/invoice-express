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
    public string FilePath { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath );
        var estimate = JsonSerializer.Deserialize<EstimateData>( json )!;


        /*
         * 
         */
        var res = await api.EstimateUpdateAsync( estimate );

        return 0;
    }
}
