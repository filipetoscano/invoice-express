using InvoiceXpress.Payloads;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace InvoiceXpress;

/// <summary />
public partial class InvoiceXpressClient : IDisposable
{
    /// <summary />
    public InvoiceXpressClient( IOptions<InvoiceXpressOptions> options, HttpClient client )
    {
        _options = options.Value;


        var rco = new RestClientOptions( $"https://{ _options.AccountName }.app.invoicexpress.com/" )
        {
            ConfigureMessageHandler = _options.ConfigureMessageHandler,
        };

        _rest = new RestClient( rco )
            .UseJson()
            .AddDefaultHeader( "User-Agent", "invoicexpress-dotnet/1.0" )
            .AddDefaultQueryParameter( "api_key", _options.ApiKey );

        _rest.AcceptedContentTypes = new string[] { "application/json" };

        _client = client;
    }


    /// <summary />
    public void Dispose()
    {
        _rest?.Dispose();
        GC.SuppressFinalize( this );
    }


    /// <summary />
    private static ApiPaginatedResult<Tresp> Error2<Tresp>( RestResponse resp )
    {
        // 422
        if ( resp.StatusCode == HttpStatusCode.UnprocessableEntity )
        {
            var body = resp.Response<ErrorPayload>();
            return new ApiPaginatedResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };
        }

        // 401
        if ( resp.StatusCode == HttpStatusCode.Unauthorized )
            return new ApiPaginatedResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 404
        if ( resp.StatusCode == HttpStatusCode.NotFound )
            return new ApiPaginatedResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 409
        if ( resp.StatusCode == HttpStatusCode.Conflict )
            return new ApiPaginatedResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 500
        if ( resp.StatusCode == HttpStatusCode.InternalServerError )
            return new ApiPaginatedResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        throw new InvalidOperationException();
    }


    /// <summary />
    private static ApiResult<Tresp> Error<Tresp>( RestResponse resp )
    {
        // 422
        if ( resp.StatusCode == HttpStatusCode.UnprocessableEntity )
        {
            var body = resp.Response<ErrorPayload>();
            return new ApiResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };
        }

        // 401
        if ( resp.StatusCode == HttpStatusCode.Unauthorized )
            return new ApiResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 404
        if ( resp.StatusCode == HttpStatusCode.NotFound )
            return new ApiResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 409
        if ( resp.StatusCode == HttpStatusCode.Conflict )
            return new ApiResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 500
        if ( resp.StatusCode == HttpStatusCode.InternalServerError )
            return new ApiResult<Tresp>() { IsSuccessful = false, StatusCode = resp.StatusCode };

        throw new InvalidOperationException();
    }


    /// <summary />
    private static ApiResult Error( RestResponse resp )
    {
        // 422
        if ( resp.StatusCode == HttpStatusCode.UnprocessableEntity )
        {
            var body = resp.Response<ErrorPayload>();
            return new ApiResult() { IsSuccessful = false, StatusCode = resp.StatusCode };
        }

        // 401
        if ( resp.StatusCode == HttpStatusCode.Unauthorized )
            return new ApiResult() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 404
        if ( resp.StatusCode == HttpStatusCode.NotFound )
            return new ApiResult() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 409
        if ( resp.StatusCode == HttpStatusCode.Conflict )
            return new ApiResult() { IsSuccessful = false, StatusCode = resp.StatusCode };

        // 500
        if ( resp.StatusCode == HttpStatusCode.InternalServerError )
            return new ApiResult() { IsSuccessful = false, StatusCode = resp.StatusCode };

        throw new InvalidOperationException();
    }


    /// <summary />
    private static ApiResult<T> Ok<T>( T result )
    {
        return new ApiResult<T>( result );
    }


    /// <summary />
    private static ApiPaginatedResult<T> Ok<T>( List<T> result, Payloads.Pagination pagination )
    {
        return new ApiPaginatedResult<T>( result, new Pagination()
        {
            EntryCount = pagination.EntryCount,
            Page = pagination.Page,
            PageCount = pagination.PageCount,
            PageSize = pagination.PageSize,
        } );
    }


    /// <summary />
    private static string VD( DateOnly value )
    {
        return value.ToString( "dd/MM/yyyy", CultureInfo.InvariantCulture );
    }

    /// <summary />
    private static string VE<T>( T value )
    {
        var v = JsonSerializer.Serialize( value )!;
        return v.Substring( 1, v.Length - 2 );
    }


    private readonly RestClient _rest;
    private readonly HttpClient _client;
    private readonly InvoiceXpressOptions _options;
}
