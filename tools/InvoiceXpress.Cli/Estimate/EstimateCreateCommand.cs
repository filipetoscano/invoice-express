using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create an estimate" )]
public class EstimateCreateCommand
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
        var estimate = JsonSerializer.Deserialize<Estimate>( json )!;


        /*
         * 
         */
        var res = await api.EstimateCreateAsync( estimate );
        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
