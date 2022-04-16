using InvoiceXpress.Json;
using InvoiceXpress.Payloads;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Globalization;
using System.Net;

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

        _rest = new RestClient( client, rco )
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
    private static ApiResult Error( RestResponse resp )
    {
        return new ApiResult()
        {
            IsSuccessful = false,
            ResponseStatus = ToResponseStatus( resp.ResponseStatus ),
            StatusCode = resp.StatusCode,
            ErrorException = resp.ErrorException,
            Errors = ToErrors( resp ),
        };
    }


    /// <summary />
    private static ApiResult<Tresp> Error<Tresp>( RestResponse resp )
    {
        return new ApiResult<Tresp>()
        {
            IsSuccessful = false,
            ResponseStatus = ToResponseStatus( resp.ResponseStatus ),
            StatusCode = resp.StatusCode,
            ErrorException = resp.ErrorException,
            Errors = ToErrors( resp ),
        };
    }


    /// <summary />
    private static ApiPaginatedResult<Tresp> Error2<Tresp>( RestResponse resp )
    {
        return new ApiPaginatedResult<Tresp>()
        {
            IsSuccessful = false,
            ResponseStatus = ToResponseStatus( resp.ResponseStatus ),
            StatusCode = resp.StatusCode,
            ErrorException = resp.ErrorException,
            Errors = ToErrors( resp ),
        };
    }


    /// <summary />
    private static List<ApiError>? ToErrors( RestResponse resp )
    {
        if ( resp.StatusCode != HttpStatusCode.UnprocessableEntity )
            return null;

        if ( resp.Content == null )
            return null;


        // Only for 422 with content
        var errors = new List<ApiError>();
        var body = resp.Response<ErrorPayload>();

        foreach ( var er in body.Errors )
        {
            errors.Add( new ApiError()
            {
                Message = er.Message,
            } );
        }

        return errors;
    }


    /// <summary />
    private static ApiResult Ok( HttpStatusCode statusCode )
    {
        return new ApiResult()
        {
            IsSuccessful = true,
            ResponseStatus = ResponseStatus.Completed,
            StatusCode = statusCode,
        };
    }


    /// <summary />
    private static ApiResult<T> Ok<T>( HttpStatusCode statusCode, T result )
    {
        return new ApiResult<T>()
        {
            IsSuccessful = true,
            ResponseStatus = ResponseStatus.Completed,
            StatusCode = statusCode,
            Result = result,
        };
    }


    /// <summary />
    private static ApiResult<T> PartialOk<T>( HttpStatusCode statusCode, T? result )
    {
        return new ApiResult<T>()
        {
            IsSuccessful = true,
            ResponseStatus = ResponseStatus.Completed,
            StatusCode = statusCode,
            Result = result,
        };
    }


    /// <summary />
    private static ApiPaginatedResult<T> Ok<T>( HttpStatusCode statusCode, List<T> result, Payloads.Pagination pagination )
    {
        var p = new Pagination()
        {
            EntryCount = pagination.EntryCount,
            Page = pagination.Page,
            PageCount = pagination.PageCount,
            PageSize = pagination.PageSize,
        };

        return new ApiPaginatedResult<T>()
        {
            IsSuccessful = true,
            ResponseStatus = ResponseStatus.Completed,
            StatusCode = statusCode,
            Result = result,
            Pagination = p,
        };
    }


    /// <summary />
    private static ResponseStatus ToResponseStatus( RestSharp.ResponseStatus status )
    {
        return Enum.Parse<ResponseStatus>( status.ToString() );
    }


    /// <summary />
    private static string VD( DateOnly value )
    {
        return value.ToString( "dd/MM/yyyy", CultureInfo.InvariantCulture );
    }


    /// <summary />
    private static string VE<T>( T value )
        where T : Enum
    {
        return JsonEnum<T>.ToValue( value );
    }


    private readonly RestClient _rest;
    private readonly HttpClient _client;
    private readonly InvoiceXpressOptions _options;
}
