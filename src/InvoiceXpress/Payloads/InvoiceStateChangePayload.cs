using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( InvoiceStateChangePayloadConverter ) )]
public class InvoiceStateChangePayload
{
    /// <summary />
    public InvoiceType InvoiceType { get; set; }

    /// <summary />
    public InvoiceStateChange Change { get; set; } = default!;
}
