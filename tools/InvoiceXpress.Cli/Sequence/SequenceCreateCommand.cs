using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a sequence" )]
public class SequenceCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Sequence record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var seq = JsonSerializer.Deserialize<SequenceRef>( json )!;


        /*
         * 
         */
        var res = await api.SequenceCreateAsync( seq );
        Console.Write( res.Result!.Id );

        return 0;
    }
}
