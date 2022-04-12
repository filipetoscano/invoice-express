using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class ItemTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public ItemTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.ItemListAsync( 1, 50 );

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }


    /// <summary />
    [Fact]
    public async Task Suite()
    {
        /*
         * #1. How many rates are there now?
         */
        var list1 = await _client.ItemListAsync( 1, 50 );

        Assert.NotNull( list1 );
        Assert.True( list1.IsSuccessful );
        Assert.NotNull( list1.Result );
        // Assert.True( list1.Pagination!.EntryCount < 50 );

        int count = list1.Result!.Count; 


        /*
         * #2. Create one!
         */
        var item = new Item()
        {
            Code = "UTXXX",
            Description = "Unit Test",
            Unit = ItemUnitType.Unit,
            UnitPrice = 12.3m,
            Tax = new VatRate() { Code = "IVA23" },
        };

        var create = await _client.ItemCreateAsync( item );

        Assert.NotNull( create );
        Assert.True( create.IsSuccessful );
        Assert.NotNull( create.Result );
        Assert.Equal( item.Code, create.Result!.Code );
        Assert.Equal( item.Description, create.Result!.Description );
        Assert.Equal( item.UnitPrice, create.Result!.UnitPrice );

        int itemId = create.Result!.Id!.Value;


        /*
         * #3. Fetch it!
         */
        var get = await _client.ItemGetAsync( itemId );

        Assert.NotNull( get );
        Assert.True( get.IsSuccessful );
        Assert.NotNull( get.Result );
        Assert.Equal( item.Code, get.Result!.Code );
        Assert.Equal( item.Description, get.Result!.Description );
        Assert.Equal( item.UnitPrice, get.Result!.UnitPrice );
        Assert.Equal( item.Tax.Code, get.Result!.Tax!.Code );


        /*
         * #4. Update
         */
        var update = await _client.ItemUpdateAsync( new Item()
        {
            Id = itemId,
            Code = item.Code,
            Unit = ItemUnitType.Unit,
            UnitPrice = 12.3m,
            Tax = new VatRate() { Code = "VAT23" },
        } );

        Assert.NotNull( update );
        Assert.True( update.IsSuccessful );


        /*
         * #5. List must have one more!
         */
        var list2 = await _client.ItemListAsync( 1, 50 );

        Assert.NotNull( list2 );
        Assert.True( list2.IsSuccessful );
        Assert.NotNull( list2.Result );
        Assert.Equal( count + 1, list2.Result!.Count );


        /*
         * #6. Delete!
         */
        var delete = await _client.ItemDeleteAsync( itemId );

        Assert.NotNull( delete );
        Assert.True( delete.IsSuccessful );


        /*
         * #7. List must be back to original
         */
        var list3 = await _client.ItemListAsync( 1, 50 );

        Assert.NotNull( list3 );
        Assert.True( list3.IsSuccessful );
        Assert.NotNull( list3.Result );
        Assert.Equal( count, list3.Result!.Count );
    }
}
