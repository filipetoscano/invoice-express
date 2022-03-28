using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Item
{
    /// <summary>
    /// Item identifier.
    /// </summary>
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

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
    public decimal UnitPrice { get; set; }

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
}
