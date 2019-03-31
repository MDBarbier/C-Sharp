using System;
using System.Linq;
using System.Reflection;

namespace confirmversion
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic targetFrameworkAttribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                .SingleOrDefault();
            string framework = targetFrameworkAttribute.FrameworkName;
            
            Console.WriteLine($".Net Core version {framework.Split('=')[1]} is installed and working.");
        }
    }
}
