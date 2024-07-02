using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Signleton
{
    public class EHan
    {
        public static  EHan eHan= new EHan();
        private EHan()
        {
            Console.WriteLine("饿汉式单例创建");
        }

        public static EHan getInstance()
        {
            return eHan;
        }
        public void Show()
        {
            Console.WriteLine("调用饿汉方法！");
        }
    }
}
