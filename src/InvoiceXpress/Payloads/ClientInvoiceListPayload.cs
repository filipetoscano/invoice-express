using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
internal class ClientInvoiceListPayload
{
    /// <summary />
    [JsonPropertyName( "filter" )]
    public ClientInvoiceListFilter Filter { get; set; } = default!;
}


/// <summary />
internal class ClientInvoiceListFilter
{
    /// <summary />
    [JsonPropertyName( "status" )]
    public List<InvoiceState>? States { get; set; }

    /// <summary />
    [JsonPropertyName( "by_type" )]
    public List<InvoiceType>? Types { get; set; }

    /// <summary />
    [JsonPropertyName( "archived" )]
    public List<string> Archive { get; set; } = default!;
}
