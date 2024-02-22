using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netCoreMVC.Models;
using netCoreMVC.Tools;
using netCoreMVC.Utils;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace netCoreMVC.Controllers
{
   
    public class ValuesController : BaseBizController
    {

        [Auth]
        [HttpPost,HttpGet]
        public string Test()
        {
            string refmsg = "";
            var users= from u in _context.UserInfos
                       select u;
          /*  string sql = "select * from User_Infos where \"UserName\"= :NAME";
            var paramList = new[]
            {
                new OracleParameter(":NAME", OracleDbType.Varchar2) { Value = "Jha" }
            };
            DataTable dt = OrcaleHelpers.ExecuteSqlToDataTable(_context,sql,paramList);
            
            IQueryable<UserInfo> userInfos = _context.UserInfos.FromSqlRaw(sql);
            foreach(var u in userInfos)
            {
               
                    refmsg += u.UserName+"   "+ u.Password;
               
            }*/
            foreach (var user in users)
            {               
                refmsg+="❥(^_-)"+user.UserName;
            }
    
      
            return refmsg;
        }
    }
}
