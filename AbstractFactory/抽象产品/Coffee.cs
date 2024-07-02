using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.抽象产品
{
    internal class Coffee : IKFCDrink
    {
        public void show()
        {
            Console.WriteLine("咖啡！！");
        }
    }
}
