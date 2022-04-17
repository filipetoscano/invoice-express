namespace InvoiceXpress.Cli.Faker;

/// <summary />
public class BaseFaker
{
    private static readonly Random _r = new Random();


    /// <summary />
    public BaseFaker()
    {
    }


    /// <summary />
    protected int Random( int maxValue )
    {
        return _r.Next( maxValue );
    }


    /// <summary />
    protected int Random( int minValue, int maxValue )
    {
        return _r.Next( minValue, maxValue );
    }


    /// <summary />
    protected decimal RandomDecimal( decimal minValue, decimal maxValue, int decimalDigits = 2 )
    {
        var d = maxValue - minValue;
        var m = (decimal) _r.NextDouble();

        var value = m * d + minValue;
        
        return Math.Round( value, decimalDigits );
    }


    /// <summary />
    protected T RandomEnum<T>()
        where T : struct, Enum
    {
        var v = Enum.GetValues<T>();

        return v[ Random( v.Length ) ];
    }


    /// <summary />
    protected T PickRandom<T>( params T[] args )
    {
        if ( args.Length == 0 )
            throw new InvalidOperationException( "Argument list must be non-empty" );

        return args[ Random( args.Length ) ];
    }
}
