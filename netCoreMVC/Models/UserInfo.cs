using System;
using System.Collections.Generic;

namespace netCoreMVC.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string Phone { get; set; } = null!;
    }
}
