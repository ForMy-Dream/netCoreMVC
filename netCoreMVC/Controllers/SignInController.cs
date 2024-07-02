using Microsoft.AspNetCore.Mvc;
using netCoreMVC.Models;
using netCoreMVC.Utils;
using Newtonsoft.Json.Linq;

namespace netCoreMVC.Controllers
{

    [ApiController]
    public class SignInController : BaseBizController
    {
        [HttpPost,HttpGet]
        public Dictionary<string,Object> Login([FromBody] JObject obj)
        {
            /*string username = request.username;
            string password = request.password;*/
            string username =  obj["username"].ToString();
            string password =  obj["password"].ToString();
            Dictionary<string, Object> dic = new Dictionary<string, object>();

            /*UserInfo re= (UserInfo)(from e in _context.UserInfos
                    where e.UserName == username && e.Password == password
                    select e);*/
            UserInfo user = (from e in _context.UserInfos
                             where e.UserName == username && e.Password == password
                             select e).FirstOrDefault();
            if (user != null)
            {
                //这是是获取用户名和密码的，这里只是为了模拟
                AuthInfo info = new AuthInfo
                {
                    UserName = username, //用户名
                    Roles = new List<string> { "Admin", "Manage", "YQ" }, //权限
                    IsAdmin = true,
                    ExpirationTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                };//过期时间
                try
                {
                    string secret = "SecretKey" + DateTime.Now.ToString("yyyyMMdd");//口令加密秘钥（应该写到配置文件中）                                                                                
                    var token = Secretkey.Enc_SecKey(info, secret);
                    dic.Add("flag", "1");
                    dic.Add("Message", "登陆成功");
                    dic.Add("Token", token);
                }
                catch (Exception ex)
                {
                    dic.Add("flag", "-1");
                    dic.Add("Message", "登陆失败");
                    return dic;
                }


                return dic;
            }
            else
            {
                dic.Add("flag", "-1");
                dic.Add("Message", "登陆失败");
                return dic;
            }
                
        }
    }
}
