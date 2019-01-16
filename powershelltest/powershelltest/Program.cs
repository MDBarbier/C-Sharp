using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace powershelltest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " +
                        "get-service");

                // use "AddParameter" to add a single parameter to the last command/script on the pipeline.
                PowerShellInstance.AddParameter("param1", "parameter 1 value!");

                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                // loop through each output object item
                foreach (PSObject outputItem in PSOutput)
                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                        if (outputItem.Members != null)
                        {
                            var x = outputItem.Members;
                            var y = outputItem.Members.Where(a => a.Value == "Referenced Service Name").Select(a => a.Value);
                            foreach (var item in x)
                            {
                                string z = string.Empty;

                                try
                                {
                                    z = item.Value.ToString();
                                    Console.WriteLine("Service name: " + z);
                                }
                                catch (Exception)
                                { }
                                
                            }                            
                        }

                    }
                }
            }
        }
    }

   
}
