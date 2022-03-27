using InvoiceExpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
/// <remarks>
/// List of countries as per: https://invoicexpress.com/api-v2/documentation/appendix
/// </remarks>
[JsonConverter( typeof( EnumConverter ) )]
public enum Country
{
    /// <summary>
    /// Portugal
    /// </summary>
    [EnumMember( Value = "Portugal" )]
    PT,
}
