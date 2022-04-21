using System.Runtime.Serialization;

namespace InvoiceXpress;

/// <summary />
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
