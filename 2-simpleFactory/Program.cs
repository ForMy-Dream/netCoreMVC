/*
简单工厂中用于创建实例的方法是静态方法，因此简单工厂模式又被称为静态工厂方法 
不属于23种设计模式
分三种角色： 
Factory 工厂角色：一般为工厂类，简单工厂模式的核心，负责实现所有的创建具体产品的内部逻辑，可被外部直接调用

Product 抽象产品角色:它是工厂类所创建的所有对象的父类，封装了各种产品对象的公有方法，它的引入将提高系统的灵活性，
使得在工厂类中只需定义一个通用的工厂方法，因为所有创建的具体产品对象都是其子类对象。

ConcreteProduce 具体产品角色:它是简单工厂模式的创建目标，所有被创建的对象都充当这个角色的某个具体类的实例。
每一个具体产品角色都继承了抽象产品角色，需要实现在抽象产品中声明的抽象方法
 */
using _2_simpleFactory;
using System.Reflection;

Console.WriteLine();
string folder = Path.Combine(Environment.CurrentDirectory);

string file = folder + "\\Apple.dll";
Console.WriteLine(file);
Products products = ProductFactory.CreateProduct("Apple");
products.show();

Console.WriteLine("=======================");

Products products1 = ProductFactory.getInstance("Banana");
products1.show();
internal class Banana : Products
{
    public override void show()
    {
        Console.WriteLine("这是香蕉类");
        Console.WriteLine(this.Name + "   " + this.Price);
    }
    public Banana()
    {
        this.Name = "香蕉";
        this.Price = 30;
    }
}