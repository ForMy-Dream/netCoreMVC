using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Signleton
{
    public class LHan
    {
        public static  LHan? lHan;
        private LHan()
        {
            Console.WriteLine("懒汉单例构造调用！");
        }
        public static LHan getInstance()
        {
            return new LHan();
        }
        public void show()
        {
            Console.WriteLine("懒汉方法！！！");
        }
    }
}
