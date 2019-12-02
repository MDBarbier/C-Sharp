using System;
using System.Collections.Generic;
using System.Text;

namespace CDSystem
{
    public class CD
    {
        public int Stock { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public void Buy(int amount, IPaymentSystem paymentSystem)
        {
            if (Stock > 0 && ((Stock - amount) > 0) && paymentSystem.ProcessPayment())
                Stock--;
        }
    }
}
