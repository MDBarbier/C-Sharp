using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Model
{
    class List
    {
        [Key]
        public long _id { get; set; }
        public string name { get; set; }
        public string contents_json { get; set; }
    }
}
