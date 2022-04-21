using System.Runtime.Serialization;

namespace InvoiceXpress;

/// <summary />
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
