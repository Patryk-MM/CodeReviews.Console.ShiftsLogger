namespace ShiftsLogger.API.Patryk_MM.Shared;

public class Result {
    public bool IsSuccess { get; }
    public Error Error { get; set; }

    public Result(bool isSuccess, Error error) {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<T> Success<T>(T data) => new(true, Error.None, data);
    public static Result<T> Failure<T>(Error error) => new(false, error, default);
}

public class Result<T> : Result {
    public T? Data { get; set; }

    public Result(bool isSuccess, Error error, T? data) : base(isSuccess, error) {
        Data = data;
    }
}