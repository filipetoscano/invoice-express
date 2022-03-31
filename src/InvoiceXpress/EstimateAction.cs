using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum EstimateAction
{
    /// <summary />
    [EnumMember( Value = "finalized" )]
    Finalize,

    /// <summary />
    [EnumMember( Value = "deleted" )]
    Delete,

    /// <summary />
    [EnumMember( Value = "accept" )]
    Accept,

    /// <summary />
    [EnumMember( Value = "refuse" )]
    Refuse,

    /// <summary />
    [EnumMember( Value = "canceled" )]
    Cancel,
}
