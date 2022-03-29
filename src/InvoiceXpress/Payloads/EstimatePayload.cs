using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( EstimatePayloadConverter ) )]
public class EstimatePayload
{
    /// <summary />
    public Estimate Estimate { get; set; } = default!;
}
