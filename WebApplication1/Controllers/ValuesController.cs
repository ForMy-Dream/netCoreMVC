using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
   
    public class ValuesController : BizController
    {
        public ValuesController():base(typeof(ValuesController))
        {
        }
        [HttpPost, HttpGet]
        public string getString()
        {
            // 创建 ConfigurationBuilder 实例
            IConfiguration configuration = new ConfigurationBuilder()
                // 添加 JSON 格式的配置文件
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // 获取连接字符串
            string connectionString = configuration.GetConnectionString("ConStr");

            log.Info("测试");

            return connectionString;
        }

        [HttpGet, HttpPost]
        public Dictionary<string, Object> GetFun([FromBody] JObject obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
     
            string v = GetData<String>(obj, "cid");
            string user = GetData<String>(obj, "user");
            dic.Add("Cid", v);
            dic.Add("User", user);
            return dic;

        }

    }
}
