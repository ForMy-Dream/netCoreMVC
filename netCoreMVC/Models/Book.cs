using System;
using System.Collections.Generic;

namespace netCoreMVC.Models
{
    public partial class Book
    {
        public long Id { get; set; }
        public string? Cover { get; set; }
        public string Title { get; set; } = null!;
        public string? Author { get; set; }
        public DateTime? Indate { get; set; }
        public string? Press { get; set; }
        public string? Abs { get; set; }
        public long? Cid { get; set; }
    }
}
