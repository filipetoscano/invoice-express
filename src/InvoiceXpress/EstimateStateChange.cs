using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class EstimateStateChange
{
    /// <summary />
    [JsonPropertyName( "state" )]
    public EstimateState State { get; set; }

    /// <summary />
    public string Message { get; set; } = default!;
}
