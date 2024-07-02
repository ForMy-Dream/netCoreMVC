using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NetCoreWebApiDemo.Models
{
    [DataContract]
    public class Person
    {
        [DataMember(Name = "ID")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "PawwWord")]
        public string PassWord { get; set; }
        [DataMember(Name = "Email")]
        public string Email { get; set; }
        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

    }
}
