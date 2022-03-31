using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum InvoiceAction
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

    /// <summary />
    [EnumMember( Value = "settled" )]
    Settle,

    /// <summary />
    [EnumMember( Value = "unsettled" )]
    Unsettle,
}
