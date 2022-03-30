using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
[JsonConverter( typeof( EstimateStateChangePayloadConverter ) )]
public class EstimateStateChangePayload
{
    /// <summary />
    public EstimateType EstimateType { get; set; }

    /// <summary />
    public EstimateStateChange Change { get; set; } = default!;
}
