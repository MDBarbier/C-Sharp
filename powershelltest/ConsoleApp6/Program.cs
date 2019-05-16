using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
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
                        "$d; $s; $param1; get-service");

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
                        //TODO: do something with the output item 
                        // outputItem.BaseOBject

                        if (outputItem.GetType() == typeof(System.Management.Automation.PSObject))
                        {
                            if (outputItem.BaseObject.GetType() == typeof(System.ServiceProcess.ServiceController))
                            {
                                var baseObject = (System.ServiceProcess.ServiceController)outputItem.BaseObject;
                                Console.WriteLine("Service: " + baseObject.DisplayName);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Output item: " + outputItem.ToString());
                        }
                        
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
