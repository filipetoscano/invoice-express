using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( GuideStateChangePayloadConverter ) )]
public class GuideStateChangePayload
{
    /// <summary />
    public GuideType GuideType { get; set; }

    /// <summary />
    public GuideStateChange Change { get; set; } = default!;
}
