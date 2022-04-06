namespace InvoiceXpress;

/// <summary />
public record struct InvoiceKey( InvoiceType Type, int Id );

/// <summary />
public record struct EstimateKey( EstimateType Type, int Id );

/// <summary />
public record struct GuideKey( GuideType Type, int Id );
