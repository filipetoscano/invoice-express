using System.Net;

namespace InvoiceXpress;


/// <summary />
public enum ResponseStatus
{
    /// <summary />
    None,

    /// <summary>
    /// Response completed successfully.
    /// </summary>
    Completed,

    /// <summary />
    Error,

    /// <summary>
    /// Response timed out.
    /// </summary>
    TimedOut,

    /// <summary>
    /// Request was aborted.
    /// </summary>
    Aborted,
}


/// <summary />
public class ApiResult
{
    /// <summary />
    public bool IsSuccessful { get; set; }

    /// <summary />
    public ResponseStatus ResponseStatus { get; set; }

    /// <summary />
    public HttpStatusCode StatusCode { get; set; }

    /// <summary />
    public Exception? ErrorException { get; set; }

    /// <summary />
    public List<ApiError>? Errors { get; set; }
}


/// <summary />
public class ApiResult<T> : ApiResult
{
    /// <summary />
    public T? Result { get; set; }
}


/// <summary />
public class ApiPaginatedResult<T> : ApiResult
{
    /// <summary />
    public List<T>? Result { get; set; }

    /// <summary />
    public Pagination? Pagination { get; set; }
}


/// <summary />
public class ApiError
{
    /// <summary />
    public string Message { get; set; } = default!;
}
