using InvoiceXpress.Cli.Faker;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "random", Description = "Generates a random item record" )]
public class ItemRandomCommand
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
        var faker = new ItemFaker();
        var item = faker.Generate();


        /*
         * 
         */
        var json = jss.Serialize( item );

        if ( this.FilePath == null )
            console.WriteLine( json );
        else
            await File.WriteAllTextAsync( this.FilePath, json );

        return 0;
    }
}
