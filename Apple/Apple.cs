using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_simpleFactory
{
    internal class Apple : Products
    {
        public override void show()
        {
            Console.WriteLine("这是苹果类");
            Console.WriteLine(this.Name+"   "+this.Price);
        }
        public Apple()
        {
            this.Name = "苹果";
            this.Price = 10.9;
         }
    }
}
