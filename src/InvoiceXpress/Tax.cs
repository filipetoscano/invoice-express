using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Tax
{
    /// <summary />
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public long? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "value" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public decimal? Value { get; set; }

    /// <summary />
    [JsonPropertyName( "region" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public TaxRegion? Region { get; set; }

    /// <summary />
    [JsonPropertyName( "default_tax" )]
    [JsonConverter( typeof( BooleanAsNumberConverter ) )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public bool? IsDefaultTax { get; set; }
}
