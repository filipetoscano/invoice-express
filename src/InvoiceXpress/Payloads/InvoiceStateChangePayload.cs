﻿using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class InvoiceStateChangePayload
{
    /// <summary />
    [JsonPropertyName( "invoice" )]
    public InvoiceStateChange Invoice { get; set; } = default!;
}
