// See https://aka.ms/new-console-template for more information

using Animals.SDK;
using System;
using System.Reflection;
using System.Runtime.Loader;

string folder = Path.Combine(Environment.CurrentDirectory, "Animals");

var files = Directory.GetFiles(folder);

var animalTypes = new List<Type>();

foreach (var file in files)
{
    //var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
    var assembly =Assembly.LoadFrom(file);
    var types = assembly.GetTypes();
    foreach (var t in types)
    {
        //有了SDK就不用以下的操作了
        //if (t.GetMethod("Voice") != null)
        //{
        //    animalTypes.Add(t);
        //}
        if (t.GetInterfaces().Contains(typeof(IAnimal)));
        {
            var isUnfinished = t.GetCustomAttributes(false).Any(a => a.GetType() == typeof(UnfinshedAttribute));
            if (isUnfinished)
            {
                continue;
            }
            animalTypes.Add(t);
        }
    }
}
while (true)
{
    for (int i = 0; i < animalTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}.{animalTypes[i].Name}");
    }

    Console.WriteLine("========================================");
    Console.WriteLine("Please input an animal's sequence number:");

    int index = int.Parse(Console.ReadLine());
    if (index > animalTypes.Count || index < 1)
    {
        Console.WriteLine("No such an animal,Please try again");
        continue;
    }
    
    Console.WriteLine("How many times?");
    int times = int.Parse(Console.ReadLine());
    var t = animalTypes[index - 1];
    var m = t.GetMethod("Voice");
    var o = Activator.CreateInstance(t);
    //m.Invoke(o, new object[] { times });
    //改为下边的写法
    var a = o as IAnimal;
    a.Voice(times);



    Console.WriteLine("--------------------------------------------------------------------");
    Console.WriteLine("--------------------------------------------------------------------");

}
        