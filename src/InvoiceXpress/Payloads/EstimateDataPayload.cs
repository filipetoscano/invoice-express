using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( EstimateDataPayloadConverter ) )]
public class EstimateDataPayload
{
    /// <summary />
    public EstimateData Estimate { get; set; } = default!;
}
