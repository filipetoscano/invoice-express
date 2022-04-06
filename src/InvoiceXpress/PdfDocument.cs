using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class PdfDocument
{
    /// <summary />
    [JsonPropertyName( "pdfUrl" )]
    public string Url { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "signed" )]
    public bool IsSigned { get; set; }
}
