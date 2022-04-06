using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class QrCodeImagePayload
{
    /// <summary />
    [JsonPropertyName( "qr_code" )]
    public QrCodeImage QrCode { get; set; } = default!;
}


/// <summary />
public class QrCodeImage
{
    /// <summary />
    [JsonPropertyName( "url" )]
    public string Url { get; set; } = default!;
}
