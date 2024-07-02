using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.抽象产品
{
    public class Wing : IKFCFood
    {
        public void show()
        {
            Console.WriteLine("鸡翅！！");
        }
    }
}
