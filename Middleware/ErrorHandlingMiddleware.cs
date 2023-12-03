using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using System.Net;
using System.Text.Json;

namespace InsuranceApp.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundError enf)
            {
                await HandleException(context, enf);
            }
            catch (EntityInsertError eir)
            {
                await HandleException(context, eir);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            var code = new object();
            if (ex is EntityNotFoundError)
            {
                code = (ex as EntityNotFoundError).StatusCode;
            }
            else if (ex is EntityInsertError)
            {
                code = (ex as EntityInsertError).StatusCode;
            }
            else
                code = HttpStatusCode.InternalServerError;
            //var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new ErrorDetails()
            {
                StatusCode = (int)code,
                Message = ex.Message,
            });
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
