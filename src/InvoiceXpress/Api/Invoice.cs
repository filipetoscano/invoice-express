using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;
using System.Globalization;
using System.Text.Json;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Invoice>> InvoiceCreateAsync( InvoiceData invoice, string? requestUuid = null )
    {
        if ( invoice.Id.HasValue == true )
            throw new ArgumentException( ".Id property is prohibited when creating an invoice", nameof( invoice ) );

        var entityType = InvoiceEntity.ToEntityName( invoice.Type );
        var payload = new InvoiceDataPayload() { Invoice = invoice, RequestUuid = requestUuid };

        var req = new RestRequest( $"/{ entityType }.json" )
            .AddJsonBody( payload );

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
    public async Task<ApiResult> InvoiceUpdateAsync( InvoiceData invoice )
    {
        if ( invoice.Id.HasValue == false )
            throw new ArgumentException( ".Id property is required when updating an invoice", nameof( invoice ) );

        var entityType = InvoiceEntity.ToEntityName( invoice.Type );
        var payload = new InvoiceDataPayload() { Invoice = invoice };

        var req = new RestRequest( $"/{ entityType }/{ invoice.Id }.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> InvoiceStateChangeAsync( InvoiceType type, int invoiceId, InvoiceStateChange change )
    {
        if ( type != InvoiceType.Invoice
            && type != InvoiceType.SimplifiedInvoice
            && type != InvoiceType.InvoiceReceipt
            && type != InvoiceType.CreditNote
            && type != InvoiceType.DebitNote )
        {
            throw new InvalidOperationException( $"Cannot change invoice state for document type '{ type }'" );
        }

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
        var req = new RestRequest( $"/documents/{ invoiceId }/partial_payments.json" )
            .AddJsonBody( new InvoicePaymentPayload() { Payment = payment } );

        var resp = await _rest.GetAsync<ReceiptPayload>( req );

        return Result( resp!.Receipt );
    }


    /// <summary />
    public async Task<ApiResult> InvoicePaymentCancelAsync( InvoiceType type, int invoiceId, string message )
    {
        if ( type != InvoiceType.Receipt )
            throw new InvalidOperationException( $"Cannot cancel payment for document type '{ type }'" );

        var entityType = InvoiceEntity.ToEntityName( type );
        var payload = new InvoiceStateChangePayload()
        {
            InvoiceType = type,
            Change = new InvoiceStateChange()
            {
                Action = InvoiceAction.Cancel,
                Message = message,
            },
        };

        var req = new RestRequest( $"/{ entityType }/{ invoiceId }/change-state.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
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

        if ( search.Type != null && search.Type.Count > 0 )
        {
            foreach ( var i in search.Type.Distinct() )
            {
                var v = JsonSerializer.Serialize( i )!;
                req.AddQueryParameter( "type[]", v );
            }
        }

        if ( search.State != null && search.State.Count > 0 )
        {
            foreach ( var i in search.State.Distinct() )
            {
                var v = JsonSerializer.Serialize( i )!;
                req.AddQueryParameter( "status[]", v );
            }
        }

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
    public async Task<ApiResult> InvoiceSendByEmailAsync( InvoiceType type, int invoiceId, EmailMessage message )
    {
        var entityName = InvoiceEntity.ToEntityName( type );
        var payload = EmailMessagePayload.From( message );

        var req = new RestRequest( $"/{ entityName }/{ invoiceId }/email-document.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> InvoicePdfGenerateAsync( InvoiceType type, int invoiceId, bool secondCopy = false )
    {
        var req = new RestRequest( $"/api/pdf/{ invoiceId }.json" );

        if ( secondCopy == true )
            req.AddQueryParameter( "second_copy", "true" );

        var resp = await _rest.GetAsync<PdfDocumentPayload>( req );

        return Result( resp!.PdfDocument );
    }


    /// <summary />
    public async Task<ApiResult> InvoiceQrCodeImageAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }
}
