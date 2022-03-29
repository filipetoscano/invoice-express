using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( InvoicePayloadConverter ) )]
public class InvoicePayload
{
    /// <summary />
    public Invoice Invoice { get; set; } = default!;
}
