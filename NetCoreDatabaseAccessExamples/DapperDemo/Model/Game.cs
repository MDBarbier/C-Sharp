using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DapperDemo.Model
{
    class Game
    {
        [Key]
        public long _id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string store_url { get; set; }
        public decimal price { get; set; }
        public string platform { get; set; }
    }
}
