using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
public class Item
{
    /// <summary>
    /// Name of the item. Must be unique.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Item description
    /// </summary>
    [JsonPropertyName( "description" )]
    public string Description { get; set; } = default!;

    /// <summary>
    /// Item's unit price. Must be a number equal or greater than 0.0.
    /// </summary>
    [JsonPropertyName( "unit_price" )]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Unit of Measure.
    /// </summary>
    [JsonPropertyName( "unit" )]
    public string? Unit { get; set; }

    /// <summary>
    /// Quantity. Must be a number equal or greater than 0.
    /// </summary>
    [JsonPropertyName( "quantity" )]
    public decimal Quantity { get; set; }

    /// <summary>
    /// The tax applied to the item line.
    /// </summary>
    /// <remarks>
    /// If not present the default tax is applied to the item.
    /// </remarks>
    [JsonPropertyName( "tax" )]
    public Tax? Tax { get; set; }

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
