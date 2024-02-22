namespace netCoreMVC.Models
{
    public class Person
    {
     

        public Person(string v1, bool v2, DateTime dateTime)
        {
            this.Name = v1;
            this.IsVIP = v2;
            this.CreatedTime = dateTime;
        }

        public string Name { get; set; }
        public bool IsVIP { get; set; }
        public DateTime CreatedTime { get; set; }
        
    }
}
