using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.抽象工厂
{
    public class ExpFactory : IKFCFactory
    {
        public IKFCDrink GetKFCDrink()
        {
            return new Coffee();
        }

        public IKFCFood GetKFCFood()
        {
            return new Chicken();
        }
    }
}
