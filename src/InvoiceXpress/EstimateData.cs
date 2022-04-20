using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class EstimateData
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public EstimateType Type { get; set; }

    /// <summary />
    [JsonPropertyName( "date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }

    /// <summary />
    [JsonPropertyName( "due_date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly ValidUntil { get; set; }

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
    [JsonPropertyName( "client" )]
    public ClientRef Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "items" )]
    public List<DocumentItemData> Items { get; set; } = default!;


    /// <summary />
    [JsonPropertyName( "currency_code" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? ForeignCurrencyCode { get; set; }

    /// <summary />
    [JsonPropertyName( "rate" )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public decimal? ForeignExchangeRate { get; set; }
}
