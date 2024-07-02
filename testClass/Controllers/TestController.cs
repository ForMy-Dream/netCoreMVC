using Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrcaleDbHelper;
using System.Collections.Generic;
using System.Data;

namespace TestController.Controllers
{

   
    
    public class TestController : testClass.Controllers.BizController
    {
        public TestController() : base(typeof(TestController))
        {

        }
        [HttpPost, HttpGet]
        public Dictionary<String,Object> getData()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            string sql = @"SELECT * FROM person WHERE id > :ID"; // 使用参数 @ID
            Log.Info(sql);

            // 建立参数对象并设置参数值
            DataParamCol param = new DataParamCol();
            param.Add("ID", 1);

            // 执行查询并获取数据
            DataTable t = DB.QueryDataTable(sql, param);
            #region 手动序列化dataTable
            /* List<object> dataList = new List<object>();

             // 遍历 DataTable 中的每一行，并将其转换为字典
             foreach (DataRow row in t.Rows)
             {
                 Dictionary<string, object> rowData = new Dictionary<string, object>();

                 // 遍历 DataTable 中的每一列，并将列名和值添加到字典中
                 foreach (DataColumn col in t.Columns)
                 {
                     rowData.Add(col.ColumnName, row[col]);
                 }

                 // 将每一行的字典添加到列表中
                 dataList.Add(rowData);
             }*/
            #endregion
            // 将列表添加到响应字典中
            response.Add("msg", t);

            // 返回字典
            return response;
        }
    }
}
