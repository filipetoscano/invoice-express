using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
/// <remarks>
/// Cannot inherit from Item, because unit_price serializes as string here! :/
/// </remarks>
public class DocumentItem
{
    /// <summary>
    /// Code of the item. Must be unique.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Code { get; set; } = default!;

    /// <summary>
    /// Item description
    /// </summary>
    [JsonPropertyName( "description" )]
    public string Description { get; set; } = default!;

    /// <summary>
    /// Item's unit price. Must be a number equal or greater than 0.0.
    /// </summary>
    /// <remarks>
    /// This is the price without VAT!
    /// </remarks>
    [JsonPropertyName( "unit_price" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal UnitPrice { get; set; } = default!;

    /// <summary>
    /// Unit of Measure.
    /// </summary>
    [JsonPropertyName( "unit" )]
    public ItemUnitType? Unit { get; set; }

    /// <summary>
    /// The tax applied to the item line.
    /// </summary>
    /// <remarks>
    /// If not present the default tax is applied to the item.
    /// </remarks>
    [JsonPropertyName( "tax" )]
    public Tax? Tax { get; set; }


    /// <summary>
    /// Quantity. Must be a number equal or greater than 0.
    /// </summary>
    [JsonPropertyName( "quantity" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Discount as a percentage.
    /// </summary>
    [JsonPropertyName( "discount" )]
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Discounted amount.
    /// </summary>
    /// <remarks>
    /// `DiscountAmount = Quantity * UnitPrice * DiscountPercentage`
    /// </remarks>
    [JsonPropertyName( "discount_amount" )]
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Line total, sans taxes after discounts.
    /// </summary>
    /// <remarks>
    /// `SubTotal = (Quantity * UnitPrice) * (1 - DiscountPercentage)`
    /// </remarks>
    [JsonPropertyName( "subtotal" )]
    public decimal SubTotalAmount { get; set; }

    /// <summary>
    /// Line amount in taxes.
    /// </summary>
    [JsonPropertyName( "tax_amount" )]
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Line total, with taxes after discounts.
    /// </summary>
    [JsonPropertyName( "total" )]
    public decimal TotalAmount { get; set; }
}
