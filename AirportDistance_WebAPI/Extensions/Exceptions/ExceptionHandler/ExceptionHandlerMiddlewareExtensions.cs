namespace AirportDistance_WebAPI.Extensions.Exceptions.ExceptionHandler
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
