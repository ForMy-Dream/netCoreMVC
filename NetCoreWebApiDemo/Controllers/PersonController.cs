using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreWebApiDemo.Models;
using NetCoreWebApiDemo.utils;
using System.Data;

namespace NetCoreWebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : BizController
    {
        /// <summary>
        /// 依赖注入方式
        /// </summary>
        /// <param name="dbHelperOracle"></param>
        public PersonController(DbHelperOracle dbHelperOracle, ILogger<PersonController> log) : base(dbHelperOracle,log)
        {

        }
        [HttpPost,HttpGet]
        public void demo()
        {
            /*            string sqlQuery = "SELECT * FROM Person where id > @id";
                        DataParamCol parameters = new DataParamCol();
                        parameters.Add("id", 1);*/
            Log.LogInformation("开始记录！！");
            string sqlQuery = "SELECT * FROM Person WHERE id > :value";
            DataParamCol parameters = new DataParamCol();
            parameters.Add(":value", 1); // 添加参数值

            DataTable resultDataTable = Db.QueryDataTable(sqlQuery, parameters);

            List<Person> people = Db.ExecuteQueryList<Person>(sqlQuery, parameters);

            string sql = @"insert into person values(person_id.nextval,:Name,:PassWord,:Email,:Phone)";
            DataParamCol paramCol = new DataParamCol();
            paramCol.Add("Name", "Test");
            paramCol.Add("PassWord", "Test");
            paramCol.Add("Email", "Test");
            paramCol.Add("Phone", "Test");

           // int v = Db.ExecuteQueryNo(sql, paramCol);

            Console.WriteLine("ada");
        }
    }
}
