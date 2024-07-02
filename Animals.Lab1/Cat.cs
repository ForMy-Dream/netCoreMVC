using Animals.SDK;

namespace Animals.Lab1
{
    public class Cat :IAnimal
    {
        public void Voice(int times)
        {
            for (int i=0; i < times; i++) { 
            Console.WriteLine("猫咪第{0}次叫！！！！",i+1);
            }
        }
    }
}