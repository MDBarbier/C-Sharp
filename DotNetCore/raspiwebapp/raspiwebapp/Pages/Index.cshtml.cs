using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace raspiwebapp.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            dynamic targetFrameworkAttribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                .SingleOrDefault();

            string framework = targetFrameworkAttribute.FrameworkName;

            string error = string.Empty;
            string temp = string.Empty;

            try
            {   
#if DEBUG
                temp = System.IO.File.ReadAllText("c:\\bashscripts\\temp.txt");
#endif
#if RELEASE
                temp = System.IO.File.ReadAllText("/bashscripts/temp.txt");
#endif

                temp = temp.Split('=')[1];
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            ViewData["Temp"] = temp;
            ViewData["Error"] = error;
            ViewData["Version"] = framework;
            ViewData["Hostname"] = Dns.GetHostName();
            ViewData["OSVersion"] = Environment.OSVersion;
            ViewData["SixtyFourBit"] = Environment.Is64BitOperatingSystem;
        }
    }
}
