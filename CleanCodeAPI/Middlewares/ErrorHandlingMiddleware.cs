using CleanCodeAPI.Models;

namespace CleanCodeAPI.Middlewares
{
  public class ErrorHandlingMiddleware : IMiddleware
  {
    private ILogger<ErrorHandlingMiddleware> logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
      this.logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

      try
      {
        // diğer middleware geç request devam ettir.
        await next(context);
      }
      catch (Exception ex)
      {
        context.Response.StatusCode = 500;

        // uygulama genelinde exception loglama
        this.logger.LogError($"{ex.Message}");

        await context.Response.WriteAsJsonAsync<ErrorModel>(new ErrorModel { Message = ex.Message });

        // next yazmayıp süreci kesintiye uğratıyorum

      }

    }
  }
}
