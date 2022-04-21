using System.Runtime.Serialization;

namespace InvoiceXpress;

/// <summary />
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
