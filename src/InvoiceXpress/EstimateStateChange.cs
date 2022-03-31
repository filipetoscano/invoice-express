using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class EstimateStateChange
{
    /// <summary />
    [JsonPropertyName( "state" )]
    public EstimateAction Action { get; set; }

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = default!;
}
