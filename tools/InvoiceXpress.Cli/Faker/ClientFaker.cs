namespace InvoiceXpress.Cli.Faker;

/// <summary />
public class ClientFaker : BaseFaker, IFaker<Client>
{
    /// <summary />
    public ClientFaker()
    {
    }


    /// <summary />
    public Client Generate()
    {
        var type = RandomEnum<EntityType>();

        var obj = new Client();
        obj.Code = "RCC" + Random( 1000, 9999 );
        obj.Name = RandomName();
        obj.Language = PickRandom( "en", "pt" );
        obj.Email = "x" + Random( 1000, 9999 ) + "@example.com";
        obj.Address = "Line 1\n\rLine 2";
        
        obj.Country = "PT";
        obj.PostalCode = RandomPostalCode();
        obj.City = PickRandom( "Beja", "Leiria", "Lisboa", "Porto" );
        obj.TaxNumber = RandomTaxNumber( obj.Country, type );

        obj.PreferredContact = new ClientContact();
        obj.Name = RandomName();

        obj.DocumentSendOptions = RandomEnum<SendOptions>();
        obj.PaymentDays = PickRandom( 0, 0, 15, 30 );
        obj.TaxExemptionCode = PickRandom( VatExemption.M00, VatExemption.M00, VatExemption.M00, VatExemption.M00, VatExemption.M01 );

        return obj;
    }


    /// <summary />
    private string RandomName()
    {
        return "X";
    }


    /// <summary />
    private string RandomPostalCode()
    {
        return Random( 1000, 5000 ) + "-" + Random( 100, 999 );
    }


    /// <summary />
    private string? RandomTaxNumber( string country, EntityType entity )
    {
        if ( country != "PT" )
            return null;

        return RandomTaxNumberPT( country, entity );
    }


    private static readonly int[] _ptWeights = { 9, 8, 7, 6, 5, 4, 3, 2 };

    /// <summary />
    private string RandomTaxNumberPT( string country, EntityType entity )
    {
        string lead;

        if ( entity == EntityType.Company )
            lead = PickRandom( "5", "6" );
        else
            lead = PickRandom( "1", "2", "3" );

        string nr = lead + Random( 0, 9999999 ).ToString().PadLeft( 7, '0' );

        var sum = nr.WeighedSum( _ptWeights );
        var checkDigit = 11 - sum % 11;

        return nr + checkDigit;
    }
}
