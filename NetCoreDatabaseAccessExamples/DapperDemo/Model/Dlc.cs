using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DapperDemo.Model
{
    class Dlc
    {
        [Key]
        public long _id { get; set; }
        public string name { get; set; }
        public long parentgameid { get; set; }
        public string store_url { get; set; }
        public decimal price { get; set; }
        public string platform { get; set; }
    }
}
