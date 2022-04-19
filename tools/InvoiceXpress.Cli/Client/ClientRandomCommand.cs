using InvoiceXpress.Cli.Faker;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "random", Description = "Generates a random client record" )]
public class ClientRandomCommand
{
    /// <summary />
    [Option( "-o|--output", CommandOptionType.SingleValue, Description = "Write to output file" )]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( Jsonizer jss, IConsole console )
    {
        /*
         * Randomize client
         */
        var faker = new ClientFaker();
        var client = faker.Generate();


        /*
         * 
         */
        var json = jss.Serialize( client );

        if ( this.FilePath == null )
            Console.WriteLine( json );
        else
            await File.WriteAllTextAsync( this.FilePath, json );

        return 0;
    }
}
