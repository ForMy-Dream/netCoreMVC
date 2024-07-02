using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class LogHelper
    {

        private  readonly ILog Log;
        public LogHelper()
        {
            Log = LogManager.GetLogger(this.GetType().ToString());
        }
        public LogHelper(Type type)
        {
            // 使用传入的类型参数创建log4net记录器
            Log = LogManager.GetLogger(type);
        }

        public  void Debug(string msg) => Log.Debug(msg);

        public  void Info(string msg) => Log.Info(msg);

        public  void Warn(string msg) => Log.Warn(msg);

        public  void Error(string msg) => Log.Error(msg);

        public  void Fatal(string msg) => Log.Fatal(msg);
    }
}
