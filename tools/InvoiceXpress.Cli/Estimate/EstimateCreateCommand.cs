using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

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
        await Task.Delay( 0 );

        return 0;
    }
}
