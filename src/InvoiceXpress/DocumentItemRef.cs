using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class DocumentItemRef
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Code { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "description" )]
    public string Description { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "unit_price" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal UnitPrice { get; set; }

    /// <summary />
    [JsonPropertyName( "quantity" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal Quantity { get; set; }

    /// <summary />
    [JsonPropertyName( "tax" )]
    public VatRateRef VatRate { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "discount" )]
    public decimal DiscountPercentage { get; set; }
}
