using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CleanCodeAPI.Attributes
{
  public class PerformanceBenchMarkAttribute:ActionFilterAttribute
  {
    private Stopwatch stopwatch;
    // bazı instance net core uygulaması ile birlikte geliyor.
    // Ilogger için ekstra bir instance eklemeye gerek.
    private ILogger<PerformanceBenchMarkAttribute> logger;

    // IRepo<Product> bunun instance oluşnması program dosyasına injection kendimiz yapmımız lazım.
    public PerformanceBenchMarkAttribute(ILogger<PerformanceBenchMarkAttribute> logger)
    {
      stopwatch = new Stopwatch();
      this.logger = logger;
    }


    /// <summary>
    /// Actiona girmeden önce tetiklenir, OnBefore
    /// </summary>
    /// <param name="context"></param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      this.stopwatch.Start();
      this.logger.LogInformation($"istek başlatıldı => {this.stopwatch.ElapsedMilliseconds}" );

      base.OnActionExecuting(context);
    }

    /// <summary>
    /// Actiondan çıkarken tetiklenir, OnAfter
    /// </summary>
    /// <param name="context"></param>
    public override void OnActionExecuted(ActionExecutedContext context)
    {

      this.stopwatch.Stop();
      this.logger.LogInformation($"istek bitti => {this.stopwatch.ElapsedMilliseconds}"  );
      base.OnActionExecuted(context);
    }
  }
}
