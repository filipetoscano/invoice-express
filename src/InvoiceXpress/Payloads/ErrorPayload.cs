using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
internal class ErrorPayload
{
    /// <summary />
    [JsonPropertyName( "errors" )]
    public List<ErrorItem> Errors { get; set; } = default!;
}


/// <summary />
internal class ErrorItem
{
    /// <summary />
    [JsonPropertyName( "error" )]
    public string Error { get; set; } = default!;
}
