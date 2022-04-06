using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class GuideStateChange
{
    /// <summary />
    [JsonPropertyName( "state" )]
    public GuideAction Action { get; set; }

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = default!;
}
