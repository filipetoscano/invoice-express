﻿using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
/// <remarks>
/// See https://www.invoicexpress.com/api-v2/estimates/change-state-1 for list
/// of possible estimate state transitions.
/// </remarks>
[JsonConverter( typeof( EnumConverter ) )]
public enum EstimateState
{
    /// <summary>
    /// Draft estimate, not yet sent to customer.
    /// </summary>
    [EnumMember( Value = "draft" )]
    Draft,

    /// <summary>
    /// Finalized estimate, may not be updated anymore.
    /// </summary>
    [EnumMember( Value = "final" )]
    Final,

    /// <summary>
    /// Deleted estimate.
    /// </summary>
    [EnumMember( Value = "deleted" )]
    Deleted,

    /// <summary>
    /// Accepted estimate.
    /// </summary>
    [EnumMember( Value = "accepted" )]
    Accepted,

    /// <summary>
    /// Rejected/refused estimate.
    /// </summary>
    [EnumMember( Value = "refused" )]
    Refused,

    /// <summary>
    /// Canceled estimate.
    /// </summary>
    [EnumMember( Value = "canceled" )]
    Canceled,
}
