namespace InvoiceExpress;


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
