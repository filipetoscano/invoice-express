using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
/// <remarks>
/// Hack version of <see cref="VatRate" /> required for VatRateCreate, since
/// the value is serialized as a string -- rather than decimal.
/// </remarks>
internal class VatRateEx
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Code { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "value" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public decimal? Value { get; set; }

    /// <summary />
    [JsonPropertyName( "region" )]
    [JsonConverter( typeof( EnumConverter ) )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public TaxRegion? Region { get; set; }

    /// <summary />
    [JsonPropertyName( "default_tax" )]
    [JsonConverter( typeof( BooleanAsNumberConverter ) )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public bool? IsDefaultRate { get; set; }
}
