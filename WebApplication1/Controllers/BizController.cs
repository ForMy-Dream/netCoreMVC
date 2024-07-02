using Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BizController : ControllerBase
    {
        public LogHelper log;
        public BizController()
        {
            log = new LogHelper(this.GetType());
        }

        public BizController(Type type)
        {
            log = new LogHelper(type);
        }
        public static T GetData<T>(JObject obj, string key)
        {
            // 检查传入的JObject是否为空
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // 检查传入的键是否为空或者JObject中是否存在该键
            if (string.IsNullOrEmpty(key) || !obj.ContainsKey(key))
            {
                return default(T);
            }

            // 从JObject中获取指定键的值，并尝试将其转换为指定类型T
            return obj[key].ToObject<T>();
        }
    }
}
