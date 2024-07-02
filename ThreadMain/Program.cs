namespace App
{
    class ThreadMain
    {
        static void Main()
        {
            // 启动 task：
            Task<string> task = Task.Factory.StartNew<string>
              (() => DownloadString("http://www.gkarch.com"));

            // 执行其它工作，它会和 task 并行执行：
            RunSomeOtherMethod();

            // 通过 Result 属性获取返回值：
            // 如果仍在执行中, 当前进程会阻塞等待直到 task 结束：
            string result = task.Result;
            Console.WriteLine(result);
        }

        static string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
            {
                return wc.DownloadString(uri);
            }

        }

        static void RunSomeOtherMethod()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"第{i}次输出,");
            }
        }

    }

}
