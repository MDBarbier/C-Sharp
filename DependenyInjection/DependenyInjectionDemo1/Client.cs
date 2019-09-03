using System;
using System.Collections.Generic;
using System.Text;

namespace DependenyInjectionDemo1
{
    public class Client
    {
        ///
        /// This is an example of the wrong way to implement the Client class and its
        /// dependency on the Service.
        /// 
        /// 1. The client class should not be responsible for initialising the service
        /// 2. It will be impossible to mock the service
        /// 3. We haven’t followed Dependency In Dependency principle and the Liskov Substitution Principle
        ///        
        //public void InitiateServiceMethod()
        //{
        //    var service = new Service();
        //    service.ServiceMethod();
        //}

        private readonly IService _service;

        //The dependency is injected into the constructor when the class is created - this is known as constructor injection
        public Client(IService service)
        {
            _service = service;
        }

        public void InitiateServiceMethod()
        {
            _service.ServiceMethod();
        }


    }
}
