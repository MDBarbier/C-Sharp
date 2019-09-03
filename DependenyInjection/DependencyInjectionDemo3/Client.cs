using DependenyInjectionDemo3;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionDemo3
{

    /// <summary>
    /// This demonstrates Method based DI - where we iject the service we want as a parameter of the method
    /// </summary>
    public class Client
    {
        public void InitiateServiceMethod(IService service)
        {
            service.ServiceMethod();
        }
    }

}
