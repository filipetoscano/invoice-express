using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class GuideStateChange
{
    /// <summary />
    [JsonPropertyName( "state" )]
    [JsonConverter( typeof( EnumConverter ) )]
    public GuideAction Action { get; set; }

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = default!;
}
