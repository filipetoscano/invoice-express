using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
public class Tax
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public long? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "value" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal Value { get; set; }

    /// <summary />
    [JsonPropertyName( "region" )]
    public TaxRegion? Region { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "default_tax" )]
    [JsonConverter( typeof( BooleanAsNumberConverter ) )]
    public bool? IsDefaultTax { get; set; }
}
