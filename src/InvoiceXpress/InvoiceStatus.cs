using InvoiceExpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum InvoiceStatus
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
