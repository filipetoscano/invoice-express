﻿using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class InvoiceStateChange
{
    /// <summary />
    [JsonPropertyName( "status" )]
    public InvoiceState State { get; set; }

    /// <summary />
    public string Message { get; set; } = default!;
}