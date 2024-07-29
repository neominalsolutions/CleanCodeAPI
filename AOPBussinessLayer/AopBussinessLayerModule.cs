using AOPBussinessLayer.Aspects;
using AOPBussinessLayer.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Reflection;

namespace AOPBussinessLayer
{
  /// <summary>
  /// İlgili katmana ait servisler IoC üzerinden Module olarak register edip API uygulamasında bu module çağıracağız. Yani Net Core Implemente edeceğiz.
  /// </summary>
  public class AopBussinessLayerModule: Autofac.Module
  {
    // uygulamaya dahil edeceğimiz herşeyi Load methodunda register ediyoruz
    protected override void Load(ContainerBuilder builder)
    {

      builder.RegisterType<BenchMarkAspect>();

      // AsImplementedInterfaces() olarak servisin sonuna eklemeyi unuttuğumuzdan sınıfı register edememiş.

      builder.RegisterType<SampleService>().AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(BenchMarkAspect));

    
    }
  }
}