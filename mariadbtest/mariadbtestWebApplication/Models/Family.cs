using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mariadbtestWebApplication.Models
{
    /// <summary>
    /// Class representing a row from the database table "test_table"
    /// </summary>
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
