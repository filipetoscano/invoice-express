using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class PdfDocumentPayload
{
    /// <summary />
    [JsonPropertyName( "output" )]
    public PdfDocument PdfDocument { get; set; } = default!;
}
