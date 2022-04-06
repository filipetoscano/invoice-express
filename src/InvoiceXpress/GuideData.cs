using InvoiceXpress.Json;
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

    /// <summary>
    /// Document date.
    /// </summary>
    [JsonPropertyName( "date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }

    /// <summary />
    [JsonPropertyName( "reference" )]
    public string Reference { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "observations" )]
    public string Remarks { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "client" )]
    public ClientRef Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "items" )]
    public List<DocumentItemRef> Items { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "loaded_at" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly? LoadedOn { get; set; }

    /// <summary />
    [JsonPropertyName( "license_plate" )]
    public string VehicleLicensePlate { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "at_doc_code_id" )]
    public string? at_doc_code_id { get; set; }

    /// <summary />
    [JsonPropertyName( "address_from" )]
    public Address AddressFrom { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "address_to" )]
    public Address AddressTo { get; set; } = default!;
}
