namespace InvoiceExpress;

public partial class InvoiceExpressClient
{
    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/create
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoiceCreateAsync( Invoice invoice )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/get
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoiceGetAsync( InvoiceType type, int invoiceId )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/create
    /// </remarks>
    public async Task<ApiResult> InvoiceUpdateAsync( Invoice invoice )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/get
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoiceList( InvoiceSearch search, int page, int pageSize = 20 )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }
}
