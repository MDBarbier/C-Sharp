using System;
using System.Collections.Generic;
using System.Text;

namespace CDSystem
{
    public class UnsuccessfulPayment : IPaymentSystem
    {
        public bool ProcessPayment()
        {
            return false;
        }
    }
}
