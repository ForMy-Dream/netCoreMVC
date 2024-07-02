using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using JWT.Algorithms;
using JWT.Serializers;
using JWT;
using netCoreMVC.Models;

namespace netCoreMVC.Utils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // 在这里执行您的自定义授权逻辑
            if (!IsAuthorized(context))
            {
                // 如果未通过授权，返回 403 Forbidden
                context.Result = new ContentResult
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(new {
                        Success="false",
                        message = "Unauthorized:认证失败" 
                    
                    }) // 或者使用其他序列化方式
                };
            }

            return;
        }

        private bool IsAuthorized(AuthorizationFilterContext context)
        {


            //获取token
            var authHeader = from t in context.HttpContext.Request.Headers
                             where t.Key == "auth" || t.Key == "Auth"
                             select t.Value.FirstOrDefault();

            //验证token是否为空
            if (authHeader != null)
            {
                string token = authHeader.FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        string secret = "SecretKey" + DateTime.Now.ToString("yyyyMMdd");//口令加密秘钥（应该写到配置文件中）  

                        var authInfo = Secretkey.Dec_SecKey(token, secret);
                        if (authInfo != null)
                        {
                            DateTime ExpDate = Convert.ToDateTime(authInfo.ExpirationTime).AddHours(24);
                            //验证token是否超时，这里设置的过期时间为两小时
                            if (ExpDate < DateTime.Now && !string.IsNullOrEmpty(authInfo.ExpirationTime))
                            {

                                return false;
                            }
                            else
                            {
                                context.HttpContext.GetRouteData().Values.Add("authinfo", authInfo);
                                return true;
                            }

                        }
                        return false;
                    }
                    catch (Exception ex)
                    {

                        return false;
                    }
                }
            }
            return false;
        }
    }
}

