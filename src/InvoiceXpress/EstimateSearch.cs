using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class EstimateSearch
{
    /// <summary />
    public string? Text { get; set; }

    /// <summary />
    public List<EstimateType>? Type { get; set; }

    /// <summary />
    public List<EstimateState>? State { get; set; }

    /// <summary />
    public DateOnly? DateFrom { get; set; }

    /// <summary />
    public DateOnly? DateTo { get; set; }

    /// <summary />
    public DateOnly? DueDateFrom { get; set; }

    /// <summary />
    public DateOnly? DueDateTo { get; set; }

    /// <summary />
    public decimal? TotalBeforeTaxesFrom { get; set; }

    /// <summary />
    public decimal? TotalBeforeTaxesTo { get; set; }

    /// <summary />
    [JsonConverter( typeof( JsonStringEnumConverter ) )]
    public ArchiveFilter? Archive { get; set; }

    /// <summary />
    public string? Reference { get; set; }
}
