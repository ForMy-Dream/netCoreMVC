using System;
using System.Collections.Generic;

namespace netCoreMVC.Models
{
    public partial class Log4net
    {
        public DateTime? LogDatetime { get; set; }
        public string? LogThread { get; set; }
        public string? LogLevel { get; set; }
        public string? LogLogger { get; set; }
        public string? LogMessage { get; set; }
    }
}
