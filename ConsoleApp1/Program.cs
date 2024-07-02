using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 连接字符串，请根据实际情况修改
            string connectionString = "Data Source=172.18.100.53,1433;Initial Catalog=huayinBL;User Id=ycbl;Password=ycbl@123;";


            // SQL 查询语句
            string query = "SELECT * FROM v_cm_resultBL";

            // 创建SqlConnection对象
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // 打开连接
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    // 创建SqlCommand对象
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 执行查询，并获取查询结果
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 判断查询结果是否有数据
                            if (reader.HasRows)
                            {
                                // 读取数据
                                while (reader.Read())
                                {
                                    // 遍历所有列
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No rows found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.Read();
                }
                finally
                {
                    // 关闭连接
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        Console.WriteLine("Connection closed.");
                    }
                }
            }
        }
    }
}
