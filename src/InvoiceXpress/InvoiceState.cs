using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum InvoiceState
{
    /// <summary />
    [EnumMember( Value = "draft" )]
    Draft,

    /// <summary />
    [EnumMember( Value = "sent" )]
    Sent,

    /// <summary />
    [EnumMember( Value = "final" )]
    Final,

    /// <summary />
    [EnumMember( Value = "deleted" )]
    Deleted,

    /// <summary />
    [EnumMember( Value = "settled" )]
    Settled,

    /// <summary />
    [EnumMember( Value = "canceled" )]
    Canceled,

    /// <summary />
    [EnumMember( Value = "second_copy" )]
    SecondCopy,
}
