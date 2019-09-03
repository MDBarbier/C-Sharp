using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionDemo2
{
    /// <summary>
    /// This is an example of Property Dependency Injection
    /// 
    /// We set the Service prop to an instance of Service1 by default, but the user of the client class could re-set this to another service if they wished
    /// </summary>
    public class Client
    {
        public IService Service { get; set; }

        public Client()
        {
            Service = new Service1();
        }

        public void InitiateServiceMethod()
        {
            Service.ServiceMethod();
        }
    }
}
