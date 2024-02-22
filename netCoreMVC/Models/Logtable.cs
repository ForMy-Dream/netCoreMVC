using System;
using System.Collections.Generic;

namespace netCoreMVC.Models
{
    public partial class Logtable
    {
        public DateTime? Datetime { get; set; }
        public string? Thread { get; set; }
        public string? LevelL { get; set; }
        public string? Logger { get; set; }
        public string? Message { get; set; }
    }
}
