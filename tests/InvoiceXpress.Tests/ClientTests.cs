using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class ClientTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public ClientTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.ClientListAsync( 1 );

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }


    /// <summary />
    [Fact]
    public async Task Scenario()
    {
        /*
         * #1. How many are there now?
         */
        var list1 = await _client.ClientListAsync( 1, 50 );

        Assert.NotNull( list1 );
        Assert.True( list1.IsSuccessful );
        Assert.NotNull( list1.Result );

        int count = list1.Result!.Count;
        int maxId = list1.Result!.Select( x => x.Id!.Value ).Max();


        /*
         * #2. Create one!
         */
        var client = new Client()
        {
            Code = "UTXX" + maxId,
            Name = "Unit Test #" + maxId,
            Language = "en",
            Email = "ut@example.com",
            Address = "Address Line 1",
            City = "City",
            PostalCode = "1234-567",
            Country = "PT",
            TaxNumber = "212212745",
            Website = "https://example.com",
            Phone = "123456789",
            Fax = "123456789",
            PreferredContact = new ClientContact()
            {
                Name = "First Last",
                Email = "person@example.com",
            },
            Remarks = "Remarks",
            DocumentSendOptions = SendOptions.OriginalOnly,
            PaymentDays = 30,
            TaxExemptionCode = VatExemption.M00,
        };

        var create = await _client.ClientCreateAsync( client );

        Assert.NotNull( create );
        Assert.True( create.IsSuccessful );
        Assert.NotNull( create.Result );
        Assert.NotNull( create.Result!.Id );
        Assert.Equal( client.Code, create.Result!.Code );

        int clientId = create.Result!.Id!.Value;


        /*
         * #3. Fetch it!
         */
        var get = await _client.ClientGetAsync( clientId );

        Assert.NotNull( get );
        Assert.True( get.IsSuccessful );
        Assert.NotNull( get.Result );
        Assert.Equal( client.Code, get.Result!.Code );


        /*
         * #4. Update
         */
        var update = await _client.ClientUpdateAsync( create.Result! );

        Assert.NotNull( update );
        Assert.True( update.IsSuccessful );


        /*
         * #5. List must have one more!
         */
        var list2 = await _client.ClientListAsync( 1, 50 );

        Assert.NotNull( list2 );
        Assert.True( list2.IsSuccessful );
        Assert.NotNull( list2.Result );
        Assert.Equal( count + 1, list2.Result!.Count );
    }
}
