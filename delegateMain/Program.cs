using delegateMain;
public class Program
{
    public delegate double CaNum(double a, double b);

    public static void Main(string[] args)
    {
        #region Action内置的委托  参数为泛型 无返回
        Calculate calculate = new Calculate();
        Action action = new Action(calculate.Report);
        action();
        Action<double> action1 = new Action<double>(calculate.Test);
        action1(8);
        #endregion

        #region Func内置的委托 有返回值类型  参数为泛型

        Func<double, double, double> f1 = new Func<double, double, double>(calculate.Add);
        Func<double, double, double, double> f3 = new Func<double, double, double, double>(calculate.ThreeAdd);
        Func<double, double> f2 = new Func<double, double>(calculate.Get);
        Func<double> f4 = new Func<double>(calculate.GetNull);

        Console.WriteLine(f1(1, 2));
        Console.WriteLine(f2(9));
        Console.WriteLine(f3(1, 2, 5));
        Console.WriteLine(f4());

        #endregion

        #region 自定义委托类 最基础使用

        CaNum ca = new CaNum(calculate.Add);
        ca += calculate.Sub;        
        Console.WriteLine( ca(5, 1));
        #endregion

        #region 自定义委托类 模板方法
        ProductFactory productfactory = new ProductFactory();
        WrapFactory wrapfactory = new WrapFactory();
        Logger log = new Logger();
        GetProduct fun1 = new GetProduct(productfactory.MakePizza);              //封装着MakePizza方法     
        GetProduct fun2 = new GetProduct(productfactory.MakeToyCar);             //封装着MakeToy方法    

     
        Action<Product> log1 = new Action<Product>(log.log);
        Box box1 = wrapfactory.WrapProduct(fun1, log1);
        Box box2 = wrapfactory.WrapProduct(fun2, log1);

        Console.WriteLine(box1.Product.Name);
        Console.WriteLine(box2.Product.Name);
        #endregion

        #region 多播委托 无返回 可直接用+= 全部调用 有返回则只返回最后一个（因为顺序执行）
        CaNum calu = new CaNum(calculate.Add);
        calu += calculate.Sub;
        calu(5,3);
        #endregion

    }
}

