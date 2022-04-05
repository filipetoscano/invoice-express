using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Guide
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int Id { get; set; }

    /// <summary />
    [JsonPropertyName( "status" )]
    public GuideState State { get; set; }

    /// <summary />
    [JsonPropertyName( "archived" )]
    public bool IsArchived { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public GuideType Type { get; set; }

    /// <summary />
    [JsonPropertyName( "sequence_number" )]
    public string SequenceNumber { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "inverted_sequence_number" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? InvertedSequenceNumber { get; set; }

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
    [JsonPropertyName( "retention" )]
    public decimal? RetentionPercentage { get; set; }

    /// <summary />
    [JsonPropertyName( "permalink" )]
    public string Permalink { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "sum" )]
    public decimal SumAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "discount" )]
    public decimal DiscountAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "before_taxes" )]
    public decimal BeforeTaxesAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "taxes" )]
    public decimal TaxesAmount { get; set; }

    /// <summary>
    /// Total amount, including taxes.
    /// </summary>
    [JsonPropertyName( "total" )]
    public decimal TotalAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "currency" )]
    [JsonConverter( typeof( CurrencyCodeAsNameConverter ) )]
    public string CurrencyCode { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "client" )]
    public Client Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "items" )]
    public List<DocumentItem> Items { get; set; } = default!;

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
