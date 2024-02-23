using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netCoreMVC.Models;
using netCoreMVC.Utils;
using Newtonsoft.Json.Linq;
using static System.Reflection.Metadata.BlobBuilder;

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
        [HttpGet,HttpPost]
        public Dictionary<string,Object> SelectBooksByCid([FromBody] JObject obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int Cid=(int)obj["cid"];
            if (Cid != 0)
            {
                List<Book> books = (from n in _context.Books
                                    where n.Cid == Cid
                                    select n).ToList();
                dic.Add("falg", 1);
                dic.Add("Data", books);
                return dic;
            }
            else
                return GetAllBooks();


        }
        [HttpPost,HttpGet]
        public Dictionary<string, Object> SearchBooks([FromBody] JObject obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string str = obj["searchStr"].ToString();
            string  cid =obj["cid"].ToString();


            if (!String.IsNullOrEmpty(cid))
            {
                List<Book> books = (from n in _context.Books
                                    where (n.Title.Contains(str) || n.Author.Contains(str)) && n.Cid ==int.Parse(cid)
                                    select n).ToList();
                dic.Add("falg", 1);
                dic.Add("Data", books);
                return dic;
            }
            else
            {
                List<Book> books = (from n in _context.Books
                         where (n.Title.Contains(str) || n.Author.Contains(str)) 
                         select n).ToList();
                dic.Add("falg", 1);
                dic.Add("Data", books);
                return dic;
            }
        }

        [HttpPost, HttpGet]
        public Dictionary<string, Object> EditBook([FromBody] JObject obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            string ObjState = (string)obj["ObjState"];
            int id = (int)obj["Book"]["id"];
            int cid = (int)obj["Book"]["cid"];
            string abs = (string)obj["Book"]["abs"];
            string author = (string)obj["Book"]["author"];
            string cover = (string)obj["Book"]["cover"];
            string press = (string)obj["Book"]["press"];
            string title = (string)obj["Book"]["title"];
            if(ObjState=="U")
            {
                Book book = (from n in _context.Books
                             where n.Id==id
                             select n).FirstOrDefault();
                book.Author = author;
                book.Title=title;
                book.Cover = cover;
                book.Press = press;
                book.Abs = abs;
                book.Indate=DateTime.Now;
                book.Cid = cid;
                _context.SaveChanges();
            }
            else if (ObjState=="C")
            {

            }else if (ObjState=="D")
            {

            }
      
            return dic;
        }
    }
}
