using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_simpleFactory
{
    public abstract class Products
    {
        public String  Name { get; set; }
        public Double Price { get; set; }
        public abstract void show();
    }
}
