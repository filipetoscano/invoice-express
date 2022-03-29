using System.Runtime.Serialization;

namespace InvoiceXpress;

/// <summary />
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
