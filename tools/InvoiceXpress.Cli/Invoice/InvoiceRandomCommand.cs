using InvoiceXpress.Cli.Faker;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "random", Description = "Generates a random invoice record" )]
public class InvoiceRandomCommand
{
    /// <summary />
    [Option( "-o|--output", CommandOptionType.SingleValue, Description = "Write to output file" )]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * Randomize client
         */
        var faker = new InvoiceFaker();
        var invoice = faker.Generate();


        /*
         * 
         */
        var json = jss.Serialize( invoice );

        if ( this.FilePath == null )
            Console.WriteLine( json );
        else
            await File.WriteAllTextAsync( this.FilePath, json );

        return 0;
    }
}
