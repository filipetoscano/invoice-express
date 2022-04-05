using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum GuideType
{
    /// <summary />
    [EnumMember( Value = "Transport" )]
    DeliveryNote,

    /// <summary />
    [EnumMember( Value = "Shipping" )]
    ShippingNote,

    /// <summary />
    [EnumMember( Value = "Devolution" )]
    ReturnDeliveryNote,
}
