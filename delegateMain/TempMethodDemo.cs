using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateMain
{
    public delegate Product GetProduct();

    public class TempMethodDemo
    {
    }
    public class Product                                           //产品类
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Logger        //增加了一个Logger类，用来记录产品创建时间和价格
    {
        public void log(Product product)
        {
            Console.WriteLine("Product'{0}' creat at {1}, price is {2}", product.Name, DateTime.UtcNow, product.Price);
            Console.WriteLine("----------------------------------------------------");
        }
    }

    class Box                                              //盒子类
    {
        public Product Product { get; set; }
    }

    class WrapFactory                                      //打包类                     
    {
        public Box WrapProduct(GetProduct getProduct, Action<Product> logCallback) //模板方法
        //public Box WrapProduct(Func<Product>  getProduct) 模板方法  也可以使用系统自带的Func函数
        {
            Box box = new Box();
            Product product = getProduct.Invoke(); //委托		
            if(product.Price> 50)
            {
                logCallback(product);
            }
            box.Product = product;
            return box;
        }
    }

    class ProductFactory                                   //生产类
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza!";
            product.Price = 12;
            return product;
        }
        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "ToyCar!";
            product.Price = 120;
            return product;
        }
    }
}
