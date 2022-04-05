using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( GuideDataPayloadConverter ) )]
public class GuideDataPayload
{
    public Guide Guide { get; set; } = default!;
}
