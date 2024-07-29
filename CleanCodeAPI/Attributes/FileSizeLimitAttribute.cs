using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanCodeAPI.Attributes
{
  public class FileSizeLimitAttribute:ActionFilterAttribute
  {
    private long maxFileSize;

    // Not: Bu attribute contructoran dışarıdan dinamic bir service instance almadığında ServiceType olarak tanımlamaya gerek yok
    public FileSizeLimitAttribute(long maxFileSize = 10000)
    {
      this.maxFileSize = maxFileSize;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {

      long fileSize = context.HttpContext.Request.Form.Files.Sum(x => x.Length);


      if (context.HttpContext.Request.Method == "POST" && context.HttpContext.Request.Form.Files.Count > 0)
      {
        if (fileSize > maxFileSize)
        {
          throw new Exception("Dosya 100 MB büyük girilemez");
        }
        else
        {
          base.OnActionExecuting(context);
        }
      }
      else
      {
        base.OnActionExecuting(context);
      }

    }
  }
}
