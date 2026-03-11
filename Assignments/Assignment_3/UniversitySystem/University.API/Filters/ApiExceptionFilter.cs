using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using University.Core.Exceptions;

namespace University.API.Filters
{
    public class ApiExceptionFilter(ILogger<ApiExceptionFilter> logger) : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger = logger;

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is NotFoundException)
            {
                context.Result = Response(exception.Message, "Resource not found", StatusCodes.Status404NotFound);
                _logger.LogWarning(exception, "Resource not found");
                return;
            }

            if (exception is BusinessException businessException)
            {
                if (businessException.Errors != null && businessException.Errors.Count != 0)

                    context.Result = Response(businessException.Errors, "One or more business validation errors occurred", StatusCodes.Status400BadRequest);

                else
                    context.Result = Response(exception.Message, "One or more business validation errors occurred", StatusCodes.Status400BadRequest);

                _logger.LogWarning(exception, "One or more business validation errors occurred");

                return;
            }

            if (exception is ArgumentNullException)
            {
                context.Result = Response(exception.Message, "Missing data", StatusCodes.Status400BadRequest);
                _logger.LogWarning(exception, "Missing data");

                return;
            }

            if (exception is ArgumentOutOfRangeException outOfRange)
            {
                context.Result = Response(outOfRange.Message, "Invalid range provided", StatusCodes.Status400BadRequest);
                _logger.LogWarning(exception, "Invalid range provided");
                return;
            }

            if (exception is UnauthorizedAccessException)
            {
                context.Result = Response(exception.Message, "Access denied", StatusCodes.Status403Forbidden);
               _logger.LogWarning(exception, "Access denied");
                return;
            }

            context.Result = Response(exception.Message, "Internal server error", StatusCodes.Status500InternalServerError, exception.StackTrace);
            _logger.LogError(exception, "Unknown error occurred");
        }


        public ObjectResult Response(string message, string responseException, int status, string? stackTrace = null)
        {
            var result =
                new ApiResponse
                {
                    StatusCode = status,
                    Message = message,
                    ResponseException = responseException,
                    IsError = true,
                    Version = "1.0",
                    Result = stackTrace
                };
            return new ObjectResult(result)
            {
                StatusCode = status
            };
        }

        public ObjectResult Response(Dictionary<string, List<string>> errors, string responseException, int status, string? stackTrace = null)
        {
            var result =
                new ApiResponse
                {
                    StatusCode = status,
                    Message = responseException,
                    ResponseException = responseException,
                    IsError = true,
                    Version = "1.0",
                    Result = errors
                };
            return new ObjectResult(result)
            {
                StatusCode = status
            };
        }
    }
}
