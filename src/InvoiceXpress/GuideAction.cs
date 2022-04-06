using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum GuideAction
{
    /// <summary />
    [EnumMember( Value = "finalized" )]
    Finalize,

    /// <summary />
    [EnumMember( Value = "deleted" )]
    Delete,

    /// <summary />
    [EnumMember( Value = "canceled" )]
    Cancel,
}
