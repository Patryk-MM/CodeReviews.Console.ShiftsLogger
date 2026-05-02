namespace ShiftsLogger.API.Patryk_MM.Shared;

public class Result {
    public bool IsSuccess { get; }
    public Error Error { get; set; }

    protected Result(bool isSuccess, Error error) {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<T> Success<T>(T data) => new(true, Error.None, data);
    public static Result<T> Failure<T>(Error error) => new(false, error, default);
    public static PaginatedResult<T> Success<T>(T data, int pageNumber, int pageSize) => new(true, Error.None, data, pageNumber, pageSize);
}

public class Result<T> : Result {
    public T? Data { get; set; }

    public Result(bool isSuccess, Error error, T? data) : base(isSuccess, error) {
        Data = data;
    }
}

public class PaginatedResult<T> : Result<T> {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public PaginatedResult(bool isSuccess, Error error, T? data, int pageNumber, int pageSize) : base(isSuccess, error, data) {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
}