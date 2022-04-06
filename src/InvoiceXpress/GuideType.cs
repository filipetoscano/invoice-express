using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum GuideType
{
    /// <summary>
    /// Document which indicates a successful delivery of goods or services.
    /// </summary>
    /// <remarks>
    /// Also known as 'Goods Received Note' (GRN).
    /// </remarks>
    [EnumMember( Value = "Transport" )]
    DeliveryNote,

    /// <summary>
    /// Legal document issued to accompany the goods during transport.
    /// </summary>
    [EnumMember( Value = "Shipping" )]
    ShippingNote,

    /// <summary />
    [EnumMember( Value = "Devolution" )]
    ReturnDeliveryNote,
}
