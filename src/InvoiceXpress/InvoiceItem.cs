using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class InvoiceItem : Item
{
    /// <summary>
    /// Quantity. Must be a number equal or greater than 0.
    /// </summary>
    [JsonPropertyName( "quantity" )]
    public decimal Quantity { get; set; }

    /// <summary />
    [JsonPropertyName( "discount" )]
    public decimal Discount { get; set; }

    /// <summary />
    [JsonPropertyName( "subtotal" )]
    public decimal SubTotal { get; set; }

    /// <summary />
    [JsonPropertyName( "tax_amount" )]
    public decimal TaxAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "discount_amount" )]
    public decimal DiscountAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "total" )]
    public decimal Total { get; set; }
}
