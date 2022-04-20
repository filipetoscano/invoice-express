using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public enum TaxRegion
{
    /// <summary>
    /// Portugal, Mainland
    /// </summary>
    [EnumMember( Value = "PT" )]
    Portugal,

    /// <summary>
    /// Portugal, Açores
    /// </summary>
    [EnumMember( Value = "PT-AC" )]
    Azores,

    /// <summary>
    /// Portugal, Madeira
    /// </summary>
    [EnumMember( Value = "PT-MA" )]
    Madeira,
}
