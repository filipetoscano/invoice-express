using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class PdfDocumentPayload
{
    /// <summary />
    [JsonPropertyName( "output" )]
    public PdfDocument PdfDocument { get; set; } = default!;
}


/// <summary />
public class PdfDocument
{
    /// <summary />
    [JsonPropertyName( "pdfUrl" )]
    public string Url { get; set; } = default!;
}
