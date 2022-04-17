using InvoiceXpress.Cli.Faker;
using McMaster.Extensions.CommandLineUtils;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "random", Description = "Generates a random client record" )]
public class ClientRandomCommand
{
    /// <summary />
    [Option( "-o|--output", CommandOptionType.SingleValue, Description = "Write to output file" )]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( IConsole console )
    {
        /*
         * Randomize client
         */
        var faker = new ClientFaker();
        var client = faker.Generate();


        /*
         * 
         */
        var json = JsonSerializer.Serialize( client, new JsonSerializerOptions() { WriteIndented = true } );

        if ( this.FilePath == null )
            Console.WriteLine( json );
        else
            await File.WriteAllTextAsync( this.FilePath, json );

        return 0;
    }
}
