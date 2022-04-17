namespace InvoiceXpress.Cli.Faker;

/// <summary />
public class ItemFaker : BaseFaker, IFaker<Item>
{
    /// <summary />
    public ItemFaker()
    {
    }


    /// <summary />
    public Item Generate()
    {
        string key = Random( 10000, 99999 ) + PickRandom( "A", "B", "C", "D", "X" );

        var obj = new Item();
        obj.Code = "IC" + key;
        obj.Description = "Item " + key;
        obj.UnitPrice = RandomDecimal( 10m, 50m, 2 );
        obj.Unit = RandomEnum<ItemUnitType>();
        obj.VatRate = new VatRate();
        obj.VatRate.Code = "IVA23";

        return obj;
    }
}
