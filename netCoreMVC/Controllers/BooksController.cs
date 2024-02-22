using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netCoreMVC.Models;
using netCoreMVC.Utils;

namespace netCoreMVC.Controllers
{

  
    public class BooksController : BaseBizController
    {
     
        [HttpGet, HttpPost]
        public Dictionary<string, object> GetAllBooks()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<Book> infos = (from n in _context.Books
                                select n).ToList();
            dic.Add("falg", 1);
            dic.Add("Data", infos);
            return dic;
        }
    }
}
