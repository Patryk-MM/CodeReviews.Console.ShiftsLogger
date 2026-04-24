using System.Net;

namespace ShiftsLogger.API.Patryk_MM;

public class ServiceResponse<T> {
    public T? Data { get; set; }
    public bool Success { get; set; } = false;
    public HttpStatusCode ResponseCode { get; set; }
    public string Message { get; set; }

}
