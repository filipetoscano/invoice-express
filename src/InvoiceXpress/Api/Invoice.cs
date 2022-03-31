using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;
using System.Globalization;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Invoice>> InvoiceCreateAsync( Invoice invoice )
    {
        var entityType = InvoiceEntity.ToEntityName( invoice.Type );
        var req = new RestRequest( $"/{ entityType }.json" )
            .AddJsonBody( new InvoicePayload() { Invoice = invoice } );

        var resp = await _rest.PostAsync<InvoicePayload>( req );

        return Result( resp!.Invoice );
    }


    /// <summary />
    public async Task<ApiResult<Invoice>> InvoiceGetAsync( InvoiceType type, int invoiceId )
    {
        var entityType = InvoiceEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityType }/{ invoiceId }.json" );

        var resp = await _rest.GetAsync<InvoicePayload>( req );

        return Result( resp!.Invoice );
    }


    /// <summary />
    public async Task<ApiResult> InvoiceUpdateAsync( Invoice invoice )
    {
        var entityType = InvoiceEntity.ToEntityName( invoice.Type );
        var req = new RestRequest( $"/{ entityType }/{ invoice.Id }.json" )
            .AddJsonBody( new InvoicePayload() { Invoice = invoice } );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> InvoiceStateChangeAsync( InvoiceType type, int invoiceId, InvoiceStateChange change )
    {
        var entityType = InvoiceEntity.ToEntityName( type );
        var payload = new InvoiceStateChangePayload() { Change = change };

        var req = new RestRequest( $"/{ entityType }/{ invoiceId }/change-state.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<Invoice>>> InvoiceRelatedDocumentsAsync( InvoiceType type, int invoiceId )
    {
        var req = new RestRequest( $"/document/{ invoiceId }/related_documents.json" );

        var resp = await _rest.GetAsync<InvoiceDocumentsPayload>( req );

        return Result( resp!.Documents );
    }


    /// <summary />
    public async Task<ApiResult<Invoice>> InvoicePaymentAsync( InvoiceType type, int invoiceId, InvoicePayment payment )
    {
        var req = new RestRequest( $"/document/{ invoiceId }/partial_payments.json" )
            .AddJsonBody( new InvoicePaymentPayload() { Payment = payment } );

        var resp = await _rest.GetAsync<ReceiptPayload>( req );

        return Result( resp!.Receipt );
    }


    /// <summary />
    public async Task<ApiResult> InvoicePaymentCancelAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult<List<Invoice>>> InvoiceListAsync( InvoiceSearch search, int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/invoices.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize )
            .AddQueryParameter( "non_archived", "false" );

        if ( search.Text != null )
            req.AddQueryParameter( "text", search.Text );

        // type[]
        // status[]

        if ( search.DateFrom.HasValue == true )
            req.AddQueryParameter( "date[from]", V( search.DateFrom.Value ) );

        if ( search.DateTo.HasValue == true )
            req.AddQueryParameter( "date[to]", V( search.DateTo.Value ) );

        if ( search.DueDateFrom.HasValue == true )
            req.AddQueryParameter( "due_date[from]", V( search.DueDateFrom.Value ) );

        if ( search.DueDateTo.HasValue == true )
            req.AddQueryParameter( "due_date[to]", V( search.DueDateTo.Value ) );

        if ( search.TotalBeforeTaxesFrom.HasValue == true )
            req.AddQueryParameter( "total_before_taxes[from]", search.TotalBeforeTaxesFrom.Value );

        if ( search.TotalBeforeTaxesTo.HasValue == true )
            req.AddQueryParameter( "total_before_taxes[to]", search.TotalBeforeTaxesTo.Value );

        // archived

        var resp = await _rest.GetAsync<InvoiceListPayload>( req );

        return Result( resp!.Invoices );
    }


    /// <summary />
    private string V( DateOnly value )
    {
        return value.ToString( "dd/MM/yyyy", CultureInfo.InvariantCulture );
    }


    /// <summary />
    public async Task<ApiResult> InvoiceSendByEmailAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult> InvoicePdfGenerateAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult> InvoiceQrCodeImageAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }
}
