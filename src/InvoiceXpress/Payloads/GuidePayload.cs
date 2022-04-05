using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( GuidePayloadConverter ) )]
public class GuidePayload
{
    public Guide Guide { get; set; } = default!;
}
