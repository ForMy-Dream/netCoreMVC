using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.抽象产品
{
    public class Chicken : IKFCFood
    {
        public void show()
        {
            Console.WriteLine("炸全鸡！！");
        }
    }
}
