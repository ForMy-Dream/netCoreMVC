using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_simpleFactory
{
    public class ProductFactory
    {
        public static Products CreateProduct(string productType)
        {
            Type productTypeObj = null;

            // 遍历所有已加载的程序集
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // 获取类型对象
                productTypeObj = assembly.GetTypes().FirstOrDefault(t => t.Name == productType && typeof(Products).IsAssignableFrom(t));
                if (productTypeObj != null)
                {
                    break;
                }
            }

            if (productTypeObj == null)
            {
                throw new ArgumentException($"无法找到指定的类型: {productType}");
            }

            // 使用 Activator 创建实例
            return (Products)Activator.CreateInstance(productTypeObj);
        }

        public static Products getInstance(string productType)
        {
            Products products;
            switch (productType)
            {
                case "Apple":
                    products = new Apple();
                    break;
                case "Banana":
                    products = new Banana();
                    break;
                default:
                    products = new Apple();
                    break;
            }
            return products;
        }
    }
}
