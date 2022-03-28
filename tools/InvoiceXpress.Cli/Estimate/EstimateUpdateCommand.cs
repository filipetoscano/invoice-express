using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an estimate" )]
public class EstimateUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Invoice record, in JSON file" )]
    [Required]
    [FileExists]
    public string File { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        await Task.Delay( 0 );

        return 0;
    }
}
