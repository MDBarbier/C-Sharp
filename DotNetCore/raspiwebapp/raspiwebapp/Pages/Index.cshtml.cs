using System;
using System.Collections.Generic;
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

            ViewData["Version"] = framework;
            ViewData["Hostname"] = Dns.GetHostName();
            ViewData["OSVersion"] = Environment.OSVersion;
            ViewData["SixtyFourBit"] = Environment.Is64BitOperatingSystem;
        }
    }
}
