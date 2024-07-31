using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Types;

namespace OrcaleDbHelper
{
    public class DbHelperOracle
    {   
        private static string connectionString;
        public DbHelperOracle()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                // 添加 JSON 格式的配置文件
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // 获取连接字符串
            connectionString = configuration.GetConnectionString("ConStr");


            // 从配置中获取连接字符串

        }
        /// <summary>
        /// 获取存储过程返回数据
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteStoredProcedure(string storedProcedureName, DataParamCol parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (OracleConnection oracleConnection = new OracleConnection(connectionString))
            {
                using (OracleCommand oracleCommand = new OracleCommand(storedProcedureName, oracleConnection))
                {
                    oracleCommand.CommandType = CommandType.StoredProcedure;

                    // 添加输入参数
                    if (parameters != null)
                    {
                        OracleParameter[] values = parameters.ToArray();
                        oracleCommand.Parameters.AddRange(values);
                    }

                    // 添加输出游标参数
                    OracleParameter retCursor = new OracleParameter();
                    retCursor.ParameterName = "RetCursor"; // 确保这个名称与存储过程中的游标参数匹配
                    retCursor.Direction = ParameterDirection.Output;
                    retCursor.OracleDbType = OracleDbType.RefCursor; // 使用 OracleDbType.RefCursor
                    oracleCommand.Parameters.Add(retCursor);

                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);

                    try
                    {
                        oracleConnection.Open();
                        oracleCommand.ExecuteNonQuery(); // 执行存储过程

                        // 获取返回的游标数据
                        using (OracleDataReader reader = ((OracleRefCursor)retCursor.Value).GetDataReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                    finally
                    {
                        ((IDisposable)(object)oracleDataAdapter)?.Dispose();
                    }
                }
            }

            return dataTable;
        }


        public int ExecuteQueryNo(string sql, DataParamCol parameters=null)
        {
            int affectedRows = 0;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleParameter[] oracleParams = parameters.ToArray();

                using (OracleCommand cmd = new OracleCommand(sql, connection))
                {
                    cmd.Parameters.AddRange(oracleParams);

                    connection.Open();
                    // 使用 ExecuteNonQuery 方法执行查询，并获取受影响的行数
                    affectedRows = cmd.ExecuteNonQuery();
                }
            }

            return affectedRows;
        }

        public DataTable QueryDataTable(string sql, DataParamCol parameters=null)
        {
            DataTable dataTable = new DataTable();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleParameter[] oracleParams = parameters.ToArray();

                using (OracleCommand cmd = new OracleCommand(sql, connection))
                {
                    cmd.Parameters.AddRange(oracleParams);

                    // 使用 OracleDataAdapter 填充 DataTable
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public List<T> ExecuteQueryList<T>(string sql, DataParamCol parameters = null)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // 构建参数列表
                DynamicParameters queryParameters = null;
                if (parameters != null && parameters.ToArray().Length > 0)
                {
                    queryParameters = new DynamicParameters();
                    foreach (var param in parameters.ToArray())
                    {
                        queryParameters.Add(param.ParameterName, param.Value);
                    }
                }

                // 执行查询并映射结果到指定类型
                return connection.Query<T>(sql, queryParameters).AsList();
            }
        }

    }


}
