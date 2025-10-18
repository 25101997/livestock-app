using System.Net;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred.";

            switch (exception)
            {
                case NpgsqlException:
                    statusCode = HttpStatusCode.ServiceUnavailable;
                    message = "Cannot connect to the database. Please verify if PostgreSQL is running.";
                    break;
                case DbUpdateException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "Error performing database operation.";
                    break;
                case InvalidOperationException ex when ex.Message.Contains("ConnectionString"):
                    statusCode = HttpStatusCode.ServiceUnavailable;
                    message = "Database connection string not initialized or invalid.";
                    break;
            }

            response.StatusCode = (int)statusCode;
            return response.WriteAsJsonAsync(new { error = message });
        }
    }
}
