namespace Log_Core
{
    using log4net;
    using log4net.Config;
    using System.IO;

    public static class LoggingService
    {
        private static ILog _logger;

        static LoggingService()
        {
            // 初始化log4net
            Initialize();
        }

        public static ILog Logger
        {
            get
            {
                // 确保log4net已经初始化
                if (_logger == null)
                {
                    Initialize();
                }
                return _logger;
            }
        }

        private static void Initialize()
        {
            // 获取log4net配置文件的路径，这里假设配置文件名为 log4net.config
            var logConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "log4net.config");

            // 使用log4net进行配置
            XmlConfigurator.ConfigureAndWatch(new FileInfo(logConfigPath));

            // 获取Logger
            _logger = LogManager.GetLogger(typeof(LoggingService));
        }
    }

}