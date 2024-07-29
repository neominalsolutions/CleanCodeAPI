using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOPBussinessLayer.Aspects
{
  //[AttributeUsage(AttributeTargets.Method, Inherited = true)]
  //public class BenchMarkAttribute: Attribute{

  //  public BenchMarkAttribute()
  //  {

  //  }
  
  //}
  public class BenchMarkAttribute : Attribute,IInterceptor
  {

    public BenchMarkAttribute()
    {

    }

    public void Intercept(IInvocation invocation)
    {
      var methodInfo = invocation.MethodInvocationTarget ?? invocation.Method;
      var hasAttribute = methodInfo.GetCustomAttributes(typeof(BenchMarkAttribute)).Any();
      if(hasAttribute)
      {
        Stopwatch sp = new Stopwatch();
        sp.Start();
        Console.WriteLine($"Time Start {sp.ElapsedMilliseconds}");

        invocation.Proceed();

        sp.Stop();
        Console.WriteLine($"Time Stop {sp.ElapsedMilliseconds}");
      }
      else
      {
        invocation.Proceed(); // bir sonraki sürece geç
      }
    }
  }
}
