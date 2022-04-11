using System.Net;

namespace InvoiceXpress;

/// <summary />
public class ApiResult
{
    /// <summary />
    public HttpStatusCode StatusCode { get; set; }

    /// <summary />
    public bool IsSuccessful { get; set; }

    /// <summary />
    public List<ApiError>? Errors { get; set; }
}


/// <summary />
public class ApiError
{
    /// <summary />
    public string Key { get; set; } = default!;

    /// <summary />
    public string Message { get; set; } = default!;
}


/// <summary />
public class ApiResult<T> : ApiResult
{
    /// <summary />
    public ApiResult()
    {
    }


    /// <summary />
    public ApiResult( T result )
    {
        IsSuccessful = true;
        StatusCode = HttpStatusCode.OK;
        Result = result;
    }


    /// <summary />
    public T? Result { get; set; }
}


/// <summary />
public class ApiPaginatedResult<T> : ApiResult
{
    /// <summary />
    public ApiPaginatedResult()
    {
    }


    /// <summary />
    public ApiPaginatedResult( List<T> result, Pagination pagination )
    {
        IsSuccessful = true;
        StatusCode = HttpStatusCode.OK;
        Result = result;
        Pagination = pagination;
    }


    /// <summary />
    public List<T>? Result { get; set; }

    /// <summary />
    public Pagination? Pagination { get; set; }
}
