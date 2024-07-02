using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateMain
{
    public class Calculate
    {
        public void Report()
        {
            Console.WriteLine("里面存在三个方法");

        }
        public void Test(double i)
        {
            Console.WriteLine("里面存在{0}个方法", i);

        }
        public double Add(double a,double b)
        {
            Console.WriteLine("调用加法！");
            return a + b;
        }
        public double Get(double a)
        {
            return a;
        }
        public double Sub(double a, double b)
        {
            Console.WriteLine("调用减法！");
            return a - b;
        }
        public double ThreeAdd(double a, double b,double c)
        {
            return a +b+c;
        }

        public double GetNull()
        {
            return 8.90;
        }
    }
}
