using Animals.SDK;

namespace Animals.Lab2
{
    [Unfinshed]
    public class Dog :IAnimal
    {
        [Unfinshed]
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("狗狗第{0}次叫！！！",i+1);
            }
        }
    }
}