using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/create
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoiceCreateAsync( Invoice invoice )
    {
        var entityType = InvoiceEntity.ToEntityName( invoice.Type );
        var req = new RestRequest( $"/{ entityType }.json" )
            .AddJsonBody( new InvoicePayload() { Invoice = invoice } );

        var resp = await _rest.PostAsync<InvoicePayload>( req );

        return Result( resp!.Invoice );
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/get
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoiceGetAsync( InvoiceType type, int invoiceId )
    {
        var entityType = InvoiceEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityType }/{ invoiceId }.json" );

        var resp = await _rest.GetAsync<InvoicePayload>( req );

        return Result( resp!.Invoice );
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/update
    /// </remarks>
    public async Task<ApiResult> InvoiceUpdateAsync( Invoice invoice )
    {
        var entityType = InvoiceEntity.ToEntityName( invoice.Type );
        var req = new RestRequest( $"/{ entityType }/{ invoice.Id }.json" )
            .AddJsonBody( new InvoicePayload() { Invoice = invoice } );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/change-state
    /// </remarks>
    public async Task<ApiResult> InvoiceStateChangeAsync( InvoiceType type, int invoiceId, InvoiceStateChange change )
    {
        var entityType = InvoiceEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityType }/{ invoiceId }.json" )
            .AddJsonBody( new InvoiceStateChangePayload() { Change = change } );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/related-documents
    /// </remarks>
    public async Task<ApiResult<List<Invoice>>> InvoiceRelatedDocumentsAsync( InvoiceType type, int invoiceId )
    {
        var req = new RestRequest( $"/document/{ invoiceId }/related_documents.json" );

        var resp = await _rest.GetAsync<InvoiceDocumentsPayload>( req );

        return Result( resp!.Documents );
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/generate-payment
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoicePaymentAsync( InvoiceType type, int invoiceId, InvoicePayment payment )
    {
        var req = new RestRequest( $"/document/{ invoiceId }/partial_payments.json" )
            .AddJsonBody( new InvoicePaymentPayload() { Payment = payment } );

        var resp = await _rest.GetAsync<ReceiptPayload>( req );

        return Result( resp!.Receipt );
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/list-all
    /// </remarks>
    public async Task<ApiResult<Invoice>> InvoiceList( InvoiceSearch search, int page, int pageSize = 20 )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }
}
