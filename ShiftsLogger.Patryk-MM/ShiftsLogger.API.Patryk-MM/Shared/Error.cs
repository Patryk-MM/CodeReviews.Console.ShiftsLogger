namespace ShiftsLogger.API.Patryk_MM.Shared;

public class Error {
    public string Message { get; set; }
    public static Error None => new(string.Empty);

    public static implicit operator Error(string message) => new(message);
    public static implicit operator string(Error error) => error.Message;

    public Error(string message) {
        Message = message;
    }
}
