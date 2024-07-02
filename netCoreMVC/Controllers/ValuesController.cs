using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netCoreMVC.Models;
using netCoreMVC.Tools;
using netCoreMVC.Utils;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;

namespace netCoreMVC.Controllers
{
   
    public class ValuesController : BaseBizController
    {

        //[Auth]
        [HttpPost,HttpGet]
        public string Test(string Barcode)
        {
            /*string refmsg = "";
            var users= from u in _context.UserInfos
                       select u;
          *//*  string sql = "select * from User_Infos where \"UserName\"= :NAME";
            var paramList = new[]
            {
                new OracleParameter(":NAME", OracleDbType.Varchar2) { Value = "Jha" }
            };
            DataTable dt = OrcaleHelpers.ExecuteSqlToDataTable(_context,sql,paramList);
            
            IQueryable<UserInfo> userInfos = _context.UserInfos.FromSqlRaw(sql);
            foreach(var u in userInfos)
            {
               
                    refmsg += u.UserName+"   "+ u.Password;
               
            }*//*
            foreach (var user in users)
            {               
                refmsg+="❥(^_-)"+user.UserName;
            }
    */
            _logger.Info("kaidasdasdsdsad");
            if (Barcode.Equals("110"))
            {
                string filePath = "D:/发票.pdf"; // PDF 文件路径
                string base64String = ConvertPdfToBase64(filePath); // 将 PDF 文件转换为 base64 编码
                                                                    // ConvertBase64ToPdf(base64String, "D:/发票.pdf"); // 将 base64 编码转换为 PDF 文件并保存
                return base64String;
            }
            else return "空的";
           
        }
        static string ConvertPdfToBase64(string filePath)
        {
            // 读取 PDF 文件并将其转换为字节数组
            byte[] pdfBytes =System.IO.File.ReadAllBytes(filePath);

            // 使用 base64 编码将字节数组转换为 base64 字符串
            string base64String = Convert.ToBase64String(pdfBytes);

            return base64String;
        }

        static void ConvertBase64ToPdf(string base64String, string newFilePath)
        {
            // 使用 base64 解码将 base64 字符串转换为字节数组
            byte[] pdfBytes = Convert.FromBase64String(base64String);

            // 将字节数组保存为 PDF 文件
            System.IO.File.WriteAllBytes(newFilePath, pdfBytes);
            //HttpContext.Current.Response.Redirect("http://www.baidu.com", true);
            // 使用默认 PDF 阅读器打开文件
            //Process.Start("D:/发票.pdf");

            try
            {
                // 根据不同的操作系统选择不同的命令来启动默认浏览器
                Process.Start(new ProcessStartInfo
                {
                    FileName = "D:/发票.pdf",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}
