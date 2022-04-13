using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class VatRateTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public VatRateTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.VatRateListAsync();

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }


    /// <summary />
    [Fact]
    public async Task Scenario()
    {
        /*
         * #1. How many rates are there now?
         */
        var list1 = await _client.VatRateListAsync();

        Assert.NotNull( list1 );
        Assert.True( list1.IsSuccessful );
        Assert.NotNull( list1.Result );

        int count = list1.Result!.Count; 


        /*
         * #2. Create one!
         */
        var vat = new VatRate()
        {
            Code = "VARUT",
            Value = 28.0m,
            Region = TaxRegion.Portugal,
        };

        var create = await _client.VatRateCreateAsync( vat );

        Assert.NotNull( create );
        Assert.True( create.IsSuccessful );
        Assert.NotNull( create.Result );
        Assert.Equal( vat.Code, create.Result!.Code );
        Assert.Equal( vat.Value, create.Result!.Value );
        Assert.Equal( vat.Region, create.Result!.Region );

        int vatId = create.Result!.Id!.Value;


        /*
         * #3. Fetch it!
         */
        var get = await _client.VatRateGetAsync( vatId );

        Assert.NotNull( get );
        Assert.True( get.IsSuccessful );
        Assert.NotNull( get.Result );
        Assert.Equal( vat.Code, get.Result!.Code );
        Assert.Equal( vat.Value, get.Result!.Value );
        Assert.Equal( vat.Region, get.Result!.Region );


        /*
         * #4. Update
         */
        var update = await _client.VatRateUpdateAsync( new VatRate()
        {
            Id = vatId,
            Code = vat.Code,
            Value = 30.0m,
            Region = TaxRegion.Madeira,
        } );

        Assert.NotNull( update );
        Assert.True( update.IsSuccessful );


        /*
         * #5. List must have one more!
         */
        var list2 = await _client.VatRateListAsync();

        Assert.NotNull( list2 );
        Assert.True( list2.IsSuccessful );
        Assert.NotNull( list2.Result );
        Assert.Equal( count + 1, list2.Result!.Count );


        /*
         * #6. Delete!
         */
        var delete = await _client.VatRateDeleteAsync( vatId );

        Assert.NotNull( delete );
        Assert.True( delete.IsSuccessful );


        /*
         * #7. List must be back to original
         */
        var list3 = await _client.VatRateListAsync();

        Assert.NotNull( list3 );
        Assert.True( list3.IsSuccessful );
        Assert.NotNull( list3.Result );
        Assert.Equal( count, list3.Result!.Count );
    }
}
