using InvoiceXpress.Cli.Faker;
using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "random", Description = "Generates a random item record" )]
public class ItemRandomCommand
{
    /// <summary />
    [Option( "-o|--output", CommandOptionType.SingleValue, Description = "Write to output file" )]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * Randomize client
         */
        var faker = new ItemFaker();
        var item = faker.Generate();


        /*
         * 
         */
        var json = JsonSerializer.Serialize( item, new JsonSerializerOptions() { WriteIndented = true } );

        if ( this.FilePath == null )
            Console.WriteLine( json );
        else
            await File.WriteAllTextAsync( this.FilePath, json );

        return 0;
    }
}
