using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.抽象工厂
{
    internal class CheapFactory : IKFCFactory
    {
        public IKFCDrink GetKFCDrink()
        {
            return new Cole();
        }

        public IKFCFood GetKFCFood()
        {
            return new Wing();
        }
    }
}
