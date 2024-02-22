using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace netCoreMVC.Tools
{

    public static class OrcaleHelpers
    {
        public static DataTable ExecuteSqlToDataTable(this DbContext context, string sql, params OracleParameter[] parameters)
        {
            // 获取DbContext中的OracleConnection实例
            var connection = (context.Database.GetDbConnection() as OracleConnection) ??
                              throw new InvalidOperationException("无法转换为OracleConnection，请确保你的DbContext使用的是兼容的Oracle数据库提供者");

            // 打开数据库连接（如果尚未打开）
            connection.Open();

            // 创建一个新的OracleCommand实例，并添加参数
            using var command = new OracleCommand(sql, connection);
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            // 创建一个数据适配器以填充DataTable
            using var dataAdapter = new OracleDataAdapter(command);
            var dataTable = new DataTable();

            // 填充DataTable
            dataAdapter.Fill(dataTable);

            // 关闭连接（EF Core通常会管理此过程，但在手动操作时最好显式关闭）
            connection.Close();

            return dataTable;
        }
    }
}
