using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class DocumentItemRef
{
    /// <summary>
    /// Unique item code.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Code { get; set; } = default!;

    /// <summary>
    /// Item description.
    /// </summary>
    [JsonPropertyName( "description" )]
    public string Description { get; set; } = default!;

    /// <summary>
    /// Unit price, without taxes.
    /// </summary>
    [JsonPropertyName( "unit_price" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonPropertyName( "quantity" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Reference to VAT rate.
    /// </summary>
    [JsonPropertyName( "tax" )]
    public VatRateRef VatRate { get; set; } = default!;

    /// <summary>
    /// Discount, as percentage, before taxes.
    /// </summary>
    [JsonPropertyName( "discount" )]
    public decimal DiscountPercentage { get; set; }
}
