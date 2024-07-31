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
        public static T GetData<T>(JObject obj, string path = null)
        {
            // 检查传入的JObject是否为空
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            // 如果路径为空，直接返回 JObject 的根元素
            if (string.IsNullOrEmpty(path))
            {
                return obj.ToObject<T>(); // 将根元素转换为指定类型 T
            }

            // 根据点分隔的路径分割键
            string[] keys = path.Split('.');

            // 遍历每个键逐层获取值
            JToken currentToken = obj;
            foreach (var key in keys)
            {
                if (currentToken[key] == null)
                {
                    return default(T); // 如果某个层级的键不存在，返回默认值
                }
                currentToken = currentToken[key];
            }

            // 尝试将最后的 JToken 转换为指定类型 T
            return currentToken.ToObject<T>();
        }
    }
}
