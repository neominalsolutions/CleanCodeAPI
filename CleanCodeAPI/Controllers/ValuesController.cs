using AOPBussinessLayer.Services;
using CleanCodeAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



namespace CleanCodeAPI.Controllers
{

  //public delegate void MyRequestDelegate(string url);

  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {


    // eğer ki içerisine constructor üzerinden dinamik bir değer alıcak ise attribute ServiceFiltter attibute ile birlikte kullanılıyor 
    //[PerformanceBenchMark]
    [ServiceFilter(typeof(PerformanceBenchMarkAttribute))]
    [HttpGet]
    public IActionResult Get()
    {
      return Ok();
    }

    // Not: Exception yapısı uygulama genelinde herhangi bir yerde olucağı için exception işlemleri genel olarak tüm uygulama ilgilendirecek şekilde yapılandırılmalıdır. Attribute olarak tanımlama bu sebeple doğru bulunmamaktadır. Bunun yerine middleware tanımı yapılmalıdır.

    //[FileSizeLimit(maxFileSize: 20000)]
    [FileSizeLimit(10)]
    // [CustomException] // methodda meydana gelen hataları işleme
    [HttpPost]
    public IActionResult Post(IFormFile form)
    {

      //throw new Exception("Deneme");

      return Ok();
    }

  }
}
