namespace InvoiceXpress;

/// <summary />
public class ApiResult
{
}


/// <summary />
public class ApiResult<T> : ApiResult
{
    /// <summary />
    public ApiResult( T result )
    {
        Result = result;
    }


    /// <summary />
    public T? Result { get; set; }
}


/// <summary />
public class ApiPaginatedResult<T> : ApiResult
{
    /// <summary />
    public ApiPaginatedResult( List<T> result, Pagination pagination )
    {
        Result = result;
        Pagination = pagination;
    }


    /// <summary />
    public List<T>? Result { get; set; }

    /// <summary />
    public Pagination Pagination { get; set; }
}
