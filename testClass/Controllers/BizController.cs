using Log;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrcaleDbHelper;
using System.Data;

namespace testClass.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BizController : ControllerBase
    {
        public DbHelperOracle DB;
        public LogHelper Log;
        public BizController()
        {
             DB = new DbHelperOracle();
             Log = new LogHelper(this.GetType());
        }
        public BizController(Type type)
        {
            this.DB = new DbHelperOracle();
            this.Log= new LogHelper(type);
        }
        
    }
}
