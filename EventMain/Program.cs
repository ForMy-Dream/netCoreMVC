
namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();

            customer.Order += waiter.Action;//挂接事件。waiter的Action订阅着customer的Order
            customer.Action();
            customer.PayTheBill();
        }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);//声明一个委托类型，专门用来声明事件，约束事件处理器


    public class OrderEventArgs : EventArgs//声明用来传递消息的类，派生自EventArgs
    {

        public string DishName { get; set; }
        public string Size { get; set; }
    }


    public class Customer //事件发起者
    {
        public event OrderEventHandler Order;//声明事件Order。用OrderEventHandler来约束事件

        public double Bill { get; set; }

        public void Walkin()
        {
            Console.WriteLine("Walk in the restaurant");
        }

        public void Sitdown()
        {
            Console.WriteLine("Sit down");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think......");
                Thread.Sleep(1000);
            }

            if (this.Order != null)//等于空说明没有人订阅这个事件，会报异常
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine();
            Walkin();
            Sitdown();
            Think();
        }

        public void PayTheBill()
        {
            Console.WriteLine("I Will pay ${0}.", this.Bill);
        }
    }

    public class Waiter  //事件的响应者Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)//事件处理器
        {
            Console.WriteLine("I will serve you the dish - {0}", e.DishName);
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}
