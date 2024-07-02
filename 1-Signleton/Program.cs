/*保证一个类只创建一个实例。并提供他的全局访问点,这就是单例模式
     将类的构造函数定义为私有，即限制类外通过构造函数进行初始化
单例模式分为饿汉式单例和懒汉式单例
饿汉式单例：在定义时就直接创建
懒汉式单例：在有需要的时候再进行创建
 */

using _1_Signleton;

EHan eHan = EHan.getInstance();
eHan.Show();
Console.WriteLine("==============================");
LHan LHan = LHan.getInstance();
LHan.show();
