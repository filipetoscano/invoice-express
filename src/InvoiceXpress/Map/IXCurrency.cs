namespace InvoiceXpress.Map;

/// <summary />
internal class IXCurrency
{
    /// <summary />
    internal IXCurrency( string code, string name )
    {
        Code = code;
        Name = name;
    }


    /// <summary />
    internal string Code { get; set; } = default!;

    /// <summary />
    internal string Name { get; set; } = default!;


    /// <summary />
    internal static readonly List<IXCurrency> Map = new List<IXCurrency>()
    {
        new IXCurrency( "EUR", "Euro" ),
    };
}
