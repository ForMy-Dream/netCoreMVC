using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netCoreMVC.Models;
namespace netCoreMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseBizController : ControllerBase
    {
       /* private readonly ILogger<ValuesController> _logger;
        private readonly ILog log = LogManager.GetLogger(typeof(ValuesController));*/
        protected readonly ModelContext _context;
        private readonly ILog _logger;
        public BaseBizController(ModelContext context, ILog logger)
        {
            _context = context;
            _logger = logger;
        }
        public BaseBizController()
        {
            
            _context = new ModelContext();
            _logger = LogManager.GetLogger(typeof(HomeController));
      
           

        }
        

    }
}
