using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Invoice>> InvoiceCreateAsync( InvoiceData invoice, string? requestUuid = null,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        if ( invoice.Id.HasValue == true )
            throw new ArgumentException( ".Id property is prohibited when creating an invoice", nameof( invoice ) );

        var entityName = InvoiceEntity.ToEntityName( invoice.Type );
        var payload = new InvoiceDataPayload() { Invoice = invoice, RequestUuid = requestUuid };

        var req = new RestRequest( $"/{ entityName }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<InvoicePayload>()!;
            return Ok( resp.StatusCode, body.Invoice );
        }

        return Error<Invoice>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Invoice>> InvoiceGetAsync( InvoiceType type, int invoiceId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var entityName = InvoiceEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityName }/{ invoiceId }.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<InvoicePayload>()!;
            return Ok( resp.StatusCode, body.Invoice );
        }

        return Error<Invoice>( resp );
    }


    /// <summary />
    public async Task<ApiResult> InvoiceUpdateAsync( InvoiceData invoice,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        if ( invoice.Id.HasValue == false )
            throw new ArgumentException( ".Id property is required when updating an invoice", nameof( invoice ) );

        var entityName = InvoiceEntity.ToEntityName( invoice.Type );
        var payload = new InvoiceDataPayload() { Invoice = invoice };

        var req = new RestRequest( $"/{ entityName }/{ invoice.Id }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult> InvoiceStateChangeAsync( InvoiceType type, int invoiceId, InvoiceStateChange change,
        CancellationToken cancellationToken = default( CancellationToken ) )
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
        var payload = new InvoiceStateChangePayload()
        {
            InvoiceType = type,
            Change = change,
        };

        var req = new RestRequest( $"/{ entityType }/{ invoiceId }/change-state.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<List<Invoice>>> InvoiceRelatedDocumentsAsync( InvoiceType type, int invoiceId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/document/{ invoiceId }/related_documents.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<InvoiceDocumentsPayload>()!;
            return Ok( resp.StatusCode, body.Documents );
        }

        return Error<List<Invoice>>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Invoice>> InvoicePaymentAsync( InvoiceType type, int invoiceId, InvoicePayment payment,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/documents/{ invoiceId }/partial_payments.json" )
            .AddJsonBody( new InvoicePaymentPayload() { Payment = payment } );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ReceiptPayload>()!;
            return Ok( resp.StatusCode, body.Receipt );
        }

        return Error<Invoice>( resp );
    }


    /// <summary />
    public async Task<ApiResult> InvoicePaymentCancelAsync( InvoiceType type, int invoiceId, string message,
        CancellationToken cancellationToken = default( CancellationToken ) )
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

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Invoice>> InvoiceListAsync( InvoiceSearch search, int page, int pageSize = 20,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/invoices.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        if ( search.Text != null )
            req.AddQueryParameter( "text", search.Text );

        /*
         * type[] is a required parameter. If not explicitly specified,
         * return all types of invoices.
         */
        if ( search.Type != null && search.Type.Count > 0 )
        {
            foreach ( var i in search.Type.Distinct() )
                req.AddQueryParameter( "type[]", VE( i ) );
        }
        else
        {
            foreach ( var i in Enum.GetValues<InvoiceType>() )
                req.AddQueryParameter( "type[]", VE( i ) );
        }


        /*
         * status[] is a required parameter. If not explicitly specified,
         * return all states.
         */
        if ( search.State != null && search.State.Count > 0 )
        {
            foreach ( var i in search.State.Distinct() )
                req.AddQueryParameter( "status[]", VE( i ) );
        }
        else
        {
            foreach ( var i in Enum.GetValues<InvoiceState>() )
                req.AddQueryParameter( "status[]", VE( i ) );
        }

        if ( search.DateFrom.HasValue == true )
            req.AddQueryParameter( "date[from]", VD( search.DateFrom.Value ) );

        if ( search.DateTo.HasValue == true )
            req.AddQueryParameter( "date[to]", VD( search.DateTo.Value ) );

        if ( search.DueDateFrom.HasValue == true )
            req.AddQueryParameter( "due_date[from]", VD( search.DueDateFrom.Value ) );

        if ( search.DueDateTo.HasValue == true )
            req.AddQueryParameter( "due_date[to]", VD( search.DueDateTo.Value ) );

        if ( search.TotalBeforeTaxesFrom.HasValue == true )
            req.AddQueryParameter( "total_before_taxes[from]", search.TotalBeforeTaxesFrom.Value );

        if ( search.TotalBeforeTaxesTo.HasValue == true )
            req.AddQueryParameter( "total_before_taxes[to]", search.TotalBeforeTaxesTo.Value );

        if ( search.Reference != null )
            req.AddQueryParameter( "reference", search.Reference );

        /*
         * non_archived is a required parameter
         */
        if ( search.Archive.HasValue == true )
        {
            req.AddQueryParameter( "non_archived", search.Archive.Value.HasFlag( ArchiveFilter.Active ) == true ? "true" : "false" );
            req.AddQueryParameter( "archived", search.Archive.Value.HasFlag( ArchiveFilter.Archived ) == true ? "true" : "false" );
        }
        else
        {
            req.AddQueryParameter( "non_archived", "true" );
        }


        /*
         * 
         */
        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<InvoiceListPayload>()!;
            return Ok( resp.StatusCode, body.Invoices, body.Pagination );
        }

        return Error2<Invoice>( resp );
    }


    /// <summary />
    public async Task<ApiResult> InvoiceSendByEmailAsync( InvoiceType type, int invoiceId, EmailMessage message,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var entityName = InvoiceEntity.ToEntityName( type );
        var payload = EmailMessagePayload.From( message );

        var req = new RestRequest( $"/{ entityName }/{ invoiceId }/email-document.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<PdfDocument>> InvoicePdfGenerateAsync( InvoiceType type, int invoiceId, bool secondCopy = false,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/api/pdf/{ invoiceId }.json" );

        if ( secondCopy == true )
            req.AddQueryParameter( "second_copy", "true" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<PdfDocumentPayload>()!;
            return Ok( resp.StatusCode, body.PdfDocument );
        }

        return Error<PdfDocument>( resp );
    }


    /// <summary />
    public async Task<ApiResult<string>> InvoiceQrCodeUrlAsync( InvoiceType type, int invoiceId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/api/qr_codes/{ invoiceId }.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<QrCodeImagePayload>()!;
            return Ok( resp.StatusCode, body.QrCode.Url );
        }

        return Error<string>( resp );
    }


    /// <summary />
    public async Task<ApiResult<byte[]>> InvoiceQrCodeImageAsync( InvoiceType type, int invoiceId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var resp = await InvoiceQrCodeUrlAsync( type, invoiceId, cancellationToken );

        if ( resp.IsSuccessful == false )
        {
            return new ApiResult<byte[]>()
            {
                IsSuccessful = resp.IsSuccessful,
                StatusCode = resp.StatusCode,
                Errors = resp.Errors,
            };
        }


        /*
         * 
         */
        var image = await _client.GetByteArrayAsync( resp.Result );

        // TODO: error handling

        return Ok( resp.StatusCode, image );
    }
}
