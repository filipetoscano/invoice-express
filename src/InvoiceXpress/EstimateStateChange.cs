using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class EstimateStateChange
{
    /// <summary />
    [JsonPropertyName( "state" )]
    [JsonConverter( typeof( EnumConverter ) )]
    public EstimateAction Action { get; set; }

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = default!;
}
