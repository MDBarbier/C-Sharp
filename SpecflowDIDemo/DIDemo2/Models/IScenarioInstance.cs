using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo2.Models
{
    interface IScenarioInstance
    {
        int NumberOfRetries { get; set; }
        int MsWaitBetweenRetries { get; set; }
    }
}
