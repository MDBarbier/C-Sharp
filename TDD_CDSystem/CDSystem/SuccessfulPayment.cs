using System;
using System.Collections.Generic;
using System.Text;

namespace CDSystem
{
    public class SuccessfulPayment : IPaymentSystem
    {
        public bool ProcessPayment()
        {
            return true;
        }
    }
}
