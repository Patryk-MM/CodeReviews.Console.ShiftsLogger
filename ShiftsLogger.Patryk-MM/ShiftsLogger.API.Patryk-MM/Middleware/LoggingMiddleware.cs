using System.Diagnostics;
using System.Net;

namespace ShiftsLogger.API.Patryk_MM.Middleware;

public class LoggingMiddleware {
    private readonly ILogger<LoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        PathString path = context.Request.Path;
        string method = context.Request.Method;
        string? ipAddress = context.Connection.RemoteIpAddress?.ToString();
        string traceId = context.TraceIdentifier;
		string? userAgent = context.Request.Headers.UserAgent;

        var stopwatch = Stopwatch.StartNew();

		_logger.LogInformation(
		"INCOMING [{TraceId}]: {Method} {Path} from {UserAgent} | {IpAddress}",
		 traceId, method, path, userAgent ?? "", ipAddress);

		await _next(context);

        stopwatch.Stop();

        int statusCode = context.Response.StatusCode;

		_logger.LogInformation(
		"OUTGOING [{TraceId}]: {Method} {Path}\nStatus: {StatusCode} {StatusName}\nElapsed: {ElapsedMs} ms",
		traceId, method, path, statusCode, (HttpStatusCode)statusCode, stopwatch.ElapsedMilliseconds);
	}
}
