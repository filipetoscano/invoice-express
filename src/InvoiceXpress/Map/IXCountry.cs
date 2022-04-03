namespace InvoiceXpress.Map;

/// <summary />
/// <remarks>
/// List of countries as per: https://invoicexpress.com/api-v2/documentation/appendix
/// </remarks>
internal partial struct IXCountry
{
    /// <summary />
    internal IXCountry( string code, string name )
    {
        Code = code;
        Name = name;
    }


    /// <summary />
    internal string Code { get; set; } = default!;

    /// <summary />
    internal string Name { get; set; } = default!;
}
