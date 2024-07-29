using AOPBussinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AutoFacAopController : ControllerBase
  {
    private readonly SampleService sampleService;

    public AutoFacAopController(SampleService sampleService)
    {
      this.sampleService = sampleService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      this.sampleService.Execute();

      return Ok();
    }

  }
}
