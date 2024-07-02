using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.抽象工厂
{
    public interface IKFCFactory
    {
        IKFCDrink GetKFCDrink();
        IKFCFood GetKFCFood();
    }
}
