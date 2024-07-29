using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanCodeAPI.Attributes
{
  public class CustomExceptionAttribute :ExceptionFilterAttribute, IAsyncExceptionFilter
  {
   
    // hatanın işlendiği kısım.
    public async Task OnExceptionAsync(ExceptionContext context)
    {

      var error = new
      {
       StatusCode = 500,
       Message =  context.Exception.Message
      };

      context.Result = new JsonResult(error);

    }
  }
}
