using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netCoreMVC.Models;
using netCoreMVC.Utils;
using Newtonsoft.Json.Linq;

namespace netCoreMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseBizController : ControllerBase
    {
       /* private readonly ILogger<ValuesController> _logger;
        private readonly ILog log = LogManager.GetLogger(typeof(ValuesController));*/
        protected readonly ModelContext _context;
        public readonly ILog _logger;
        public readonly ConsoleDemo _consoleDemo;
     /*   public BaseBizController(ModelContext context, ILog logger, ConsoleDemo consoleDemo)
        {
            _context = context;
            _logger = logger;
            _consoleDemo = consoleDemo;
        }*/
        // 服务定位器类
        public static class ServiceLocator
        {
            public static IServiceProvider Instance { get; set; }
        }
        // 辅助方法，用于从依赖注入容器中获取服务实例
        private TService GetService<TService>()
        {
            var serviceProvider = ServiceLocator.Instance;
            return serviceProvider.GetRequiredService<TService>();
        }
        public BaseBizController()
        {
            var serviceProvider = ServiceLocator.Instance;

            // 通过容器获取 ISomeService 实例
           // _consoleDemo = serviceProvider.GetRequiredService<ConsoleDemo>();
            //_consoleDemo = GetService<ConsoleDemo>();
            _context = new ModelContext();
            _logger = LogManager.GetLogger(typeof(HomeController));
            _logger.Info("写数据了！！！！");
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
