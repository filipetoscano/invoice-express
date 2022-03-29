using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class SaftExportPayload
{
    /// <summary />
    [JsonPropertyName( "url" )]
    public string? Url { get; set; }
}
