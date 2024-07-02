using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Log;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public LogHelper log;
        public TestController()
        {
             log = new LogHelper(this.GetType());
        }

        public TestController(Type type)
        {
            log = new LogHelper(type);
        }
        [HttpPost,HttpGet]
        public string getString()
        {
            log.Info("测试");
            return "asddasda";
        }
    }
}
