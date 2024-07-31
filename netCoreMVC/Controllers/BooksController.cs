using log4net;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using netCoreMVC.Models;
using netCoreMVC.Utils;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;
using static System.Reflection.Metadata.BlobBuilder;

namespace netCoreMVC.Controllers
{

  
    public class BooksController : BaseBizController
    {
        private readonly IConnection _connection;
        private readonly RabbitMQ.Client.IModel _channel;
       

      /*  public  BooksController()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
         
        }*/
        /*public BooksController(ModelContext context, ILog logger, ConsoleDemo consoleDemo) :base( context,  logger,  consoleDemo)
        {

        }*/
        [HttpPost,HttpGet]
        public string test()
        {
            _logger.Info("Books里面");
            return "数据返回！！！";
        }
        [HttpGet, HttpPost]
        public Dictionary<string, object> TestMq()
        {          
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<Book> infos = (from n in _context.Books
                                select n).ToList();

            var message = $"User {infos[0].Title} purchased book {infos[0].Cover}";
            var body = Encoding.UTF8.GetBytes(message);
            
            _channel.BasicPublish(exchange: "", routingKey: "purchase_queue", basicProperties: null, body: body);


            dic.Add("falg", 1);
            dic.Add("Data", infos);
            return dic;
        }
        [Auth]
        [HttpGet, HttpPost]
        public Dictionary<string, object> GetAllBooks()
        {
                 _logger.Info("Books里面");
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<Book> infos = (from n in _context.Books
                                select n).ToList();
            dic.Add("falg", 1);
            dic.Add("Data", infos);
            return dic;
        }

        [HttpGet, HttpPost]
        public Dictionary<string, Object> test([FromBody] JObject obj)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            
            return dic;
        }

        [HttpGet,HttpPost]
        public Dictionary<string,Object> SelectBooksByCid([FromBody] JObject obj)
        {
            /* Dictionary<string, object> dic = new Dictionary<string, object>();
             //_consoleDemo.demo();
             string v = GetData<String>(obj, "cid");
             UserInfo user = GetData<UserInfo>(obj, "User");
             //_logger.Info("Books里面");

             int Cid=(int)obj["cid"];
             *//*  if (Cid != 0)
               {
                   List<Book> books = (from n in _context.Books
                                       where n.Cid == Cid
                                       select n).ToList();
                   dic.Add("falg", 1);
                   dic.Add("Data", books);
                   return dic;
               }
               else
                   return GetAllBooks();*//*
             dic.Add("Cid", Cid);
             dic.Add("User", user);
 */     

            string userName = GetData<string>(obj, "userName");
            string pwd = GetData<string>(obj, "pwd");
            Dictionary<string, object> response = new Dictionary<string, object>();
            var user = new
            {
                id = 12,
                username = userName,
                name = pwd,
                email = "jbPj5zHELD015CPziPFPaHNdCTwLit1IXIangpGlHIY=",
                roles = new[] { "zkIri8tQ9auD88PM-EsmVw==" },
                labs = new[] { "默认实验室" }
            };

            // 创建数据部分
            var data = new
            {
                token = "9131143a5b80747483496e0e1e6241efc75d4168",
                user = user,
                msg = "登录成功"
            };

            // 填充返回对象
            response["data"] = data;
            response["status"] = "OK";
            response["code"] = "0";
            response["msg"] = "登录成功";

            return response;
            //return dic;

        }
        [HttpPost,HttpGet]
        public Dictionary<string, Object> SearchBooks(string userName,string pwd)
        {
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "total", 1 },
                { "userName",userName},
                {"pwd",pwd },
                { "status", "OK" },
                { "code", "0" },
                { "msg", "操作成功" }
            };

            // 返回 JSON 数据
            return data;
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



    public class Result
    {
        public int id { get; set; }
        public string template { get; set; }
        public int submit_record { get; set; }
        public DateTime create_time { get; set; }
        public string filename { get; set; }
        public string patient_name { get; set; }
        public string sample { get; set; }
        public string library { get; set; }
        public string chip { get; set; }
        public string sample_type { get; set; }
        public int download_times { get; set; }
        public DateTime last_download { get; set; }
        public string comment { get; set; }
    }

    public class Data
    {
        public int total { get; set; }
        public int page { get; set; }
        public int page_size { get; set; }
        public List<Result> results { get; set; }
    }

    public class RootObject
    {
        public Data data { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
}
