using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( InvoiceDataPayloadConverter ) )]
public class InvoiceDataPayload
{
    /// <summary />
    public InvoiceData Invoice { get; set; } = default!;

    /// <summary />
    public string? RequestUuid { get; set; }
}
