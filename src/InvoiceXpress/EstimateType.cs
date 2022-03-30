using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum EstimateType
{
    /// <summary />
    [EnumMember( Value = "Quote" )]
    Quote,

    /// <summary />
    [EnumMember( Value = "Proforma" )]
    Proforma,

    /// <summary />
    [EnumMember( Value = "FeesNote" )]
    FeeNote,
}
