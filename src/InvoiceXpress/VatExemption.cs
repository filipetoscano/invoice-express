namespace InvoiceXpress;

/// <summary />
/// <remarks>
/// See https://invoicexpress.com/api-v2/documentation/appendix
/// </remarks>
public static class VatExemption
{
    /// <summary>
    /// Artigo 16.º n.º 6 alínea c) do CIVA
    /// </summary>
    public const string M01 = "M01";

    /// <summary>
    /// Artigo 6.º do Decreto‐Lei n.º 198/90, de 19 de Junho
    /// </summary>
    public const string M02 = "M02";

    /// <summary>
    /// Exigibilidade de caixa
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 204/97, de 9 de Agosto;
    /// Decreto‐Lei n.º 418/99, de 21 de Outubro;
    /// Decreto-Lei n.º 15/2009, de 1 de Abril.
    /// </remarks>
    public const string M03 = "M03";

    /// <summary>
    /// Exempt due to Article 13.º do CIVA
    /// </summary>
    /// <remarks>
    /// Artigo 13.º do CIVA.
    /// </remarks>
    public const string M04 = "M04";

    /// <summary>
    /// Exempt due to Article 14.º do CIVA
    /// </summary>
    /// <remarks>
    /// Artigo 14.º do CIVA
    /// </remarks>
    public const string M05 = "M05";

    /// <summary>
    /// Exempt due to Article 15.º do CIVA
    /// </summary>
    /// <remarks>
    /// Artigo 15.º do CIVA
    /// </remarks>
    public const string M06 = "M06";

    /// <summary>
    /// Exempt due to Article 9.º do CIVA
    /// </summary>
    /// <remarks>
    /// Artigo 9.º do CIVA
    /// </remarks>
    public const string M07 = "M07";

    /// <summary>
    /// IVA – Autoliquidação
    /// </summary>
    /// <remarks>
    /// Artigo 2.º n.º 1 alínea i) do CIVA;
    /// Artigo 2.º n.º 1 alínea j) do CIVA;
    /// Artigo 6.º do CIVA;
    /// Artigo 2.º n.º 1 alínea l) do CIVA;
    /// Decreto‐Lei n.º 21/2007, de 29 de Janeiro;
    /// Decreto‐Lei n.º 362/99, de 16 de Setembro;
    /// </remarks>
    public const string M08 = "M08";

    /// <summary>
    /// IVA ‐ não confere direito a dedução
    /// </summary>
    /// <remarks>
    /// Artigo 60.º CIVA; Artigo 72.º n.º 4 do CIVA;
    /// </remarks>
    public const string M09 = "M09";

    /// <summary>
    /// IVA – Regime de isenção
    /// </summary>
    /// <remarks>
    /// Artigo 53.ºdo CIVA
    /// </remarks>
    public const string M10 = "M10";

    /// <summary>
    /// Regime particular do tabaco
    /// </summary>
    /// <remarks>
    /// Decreto-Lei n.º 346/85, de 23 de Agosto
    /// </remarks>
    public const string M11 = "M11";

    /// <summary>
    /// Regime da margem de lucro – Agências de Viagens
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 221/85, de 3 de Julho
    /// </remarks>
    public const string M12 = "M12";

    /// <summary>
    /// Regime da margem de lucro – Bens em segunda mão
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 199/96, de 18 de Outubro
    /// </remarks>
    public const string M13 = "M13";

    /// <summary>
    /// Regime da margem de lucro – Objetos de arte
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 199/96, de 18 de Outubro
    /// </remarks>
    public const string M14 = "M14";

    /// <summary>
    /// Regime da margem de lucro – Objetos de coleção e antiguidades
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 199/96, de 18 de Outubro
    /// </remarks>
    public const string M15 = "M15";

    /// <summary>
    /// Isento Artigo 14.º do RITI
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 199/96, de 18 de Outubro
    /// </remarks>
    public const string M16 = "M16";

    /// <summary>
    /// Não sujeito; não tributado (ou similar)
    /// </summary>
    /// <remarks>
    /// Decreto‐Lei n.º 199/96, de 18 de Outubro
    /// </remarks>
    public const string M99 = "M99";

    /// <summary>
    /// Não sujeito; não tributado (ou similar)
    /// </summary>
    /// <remarks>
    /// Lei n.º 13/2020 de 7 de Maio 2020
    /// </remarks>
    public const string M99_2 = "M99-2";
}
