using CleanCodeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCodeAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DIController : ControllerBase
  {
    private ScopeInstanceService sc1;
    private ScopeInstanceService sc2;
    private TransientInstanceService t1;
    private TransientInstanceService t2;
    private SingletonInstanceService s1;
    private SingletonInstanceService s2;


    public DIController(ScopeInstanceService sc1, ScopeInstanceService sc2, TransientInstanceService t1, TransientInstanceService t2, SingletonInstanceService s1, SingletonInstanceService s2)
    {
      this.sc1 = sc1;
      this.sc2 = sc2;
      this.t1 = t1;
      this.t2 = t2;
      this.s1 = s1;
      this.s2 = s2;
    }

    [HttpGet]
    public IActionResult Get()
    {


      return Ok(new {Transient1 = t1.Id, Transient2 = t2.Id,Scope1=sc1.Id,Scope2=sc2.Id,Singleton1 = s1.Id, Singleton2 = s2.Id});
    }
  }
}
