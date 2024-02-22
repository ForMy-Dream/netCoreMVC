using Microsoft.AspNetCore.Mvc;
using netCoreMVC.Models;

namespace netCoreMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Demo1(int a) //返回类型为IActionResult
        {
            var model = new Person("Zack", true, new DateTime(1999, 9, 9));
            return View(model);//将model对象传递给与操作方法同名的View
        }

    }
}
