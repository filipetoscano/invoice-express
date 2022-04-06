using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class GuideData
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public GuideType Type { get; set; }
}
