using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary>
/// Unit type by which the item is measured.
/// </summary>
[JsonConverter( typeof( EnumConverter ) )]
public enum ItemUnitType
{
    /// <summary>
    /// Item is a provided service.
    /// </summary>
    [EnumMember( Value = "service" )]
    Service,

    /// <summary>
    /// Item is a good, sold in units.
    /// </summary>
    [EnumMember( Value = "unit" )]
    Unit,

    /// <summary>
    /// Item is sold by the hour.
    /// </summary>
    [EnumMember( Value = "hour" )]
    Hour,

    /// <summary>
    /// Item is sold by the day.
    /// </summary>
    [EnumMember( Value = "day" )]
    Day,

    /// <summary>
    /// Item is sold by the month.
    /// </summary>
    [EnumMember( Value = "month" )]
    Month,

    /// <summary>
    /// Item has another unit-of-measurement (eg, Kilo, L, etc)
    /// </summary>
    [EnumMember( Value = "other" )]
    Other,
}
