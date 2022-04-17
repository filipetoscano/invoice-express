using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary>
/// Value-added tax (VAT) rate definition.
/// </summary>
public class VatRate
{
    /// <summary />
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

    /// <summary>
    /// Unique code of VAT rate.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Code { get; set; } = default!;

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
    public bool? IsDefaultRate { get; set; }
}


/// <summary>
/// Reference to an existing VAT rate.
/// </summary>
public class VatRateRef
{
    /// <summary>
    /// Unique code of VAT rate.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Code { get; set; } = default!;
}
