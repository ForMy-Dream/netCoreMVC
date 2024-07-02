using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApiDemo.utils;

namespace NetCoreWebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BizController : ControllerBase
    {
        public DbHelperOracle Db;
        public ILogger<BizController> Log;
        /// <summary>
        /// 依赖注入方式
        /// </summary>
        /// <param name="dbHelperOracle"></param>
        public BizController(DbHelperOracle dbHelperOracle, ILogger<BizController> Log)
        {
            this.Db = dbHelperOracle;
            this.Log = Log;
        }
        public BizController()
        {
            Db=new DbHelperOracle();
        }
    }
}
