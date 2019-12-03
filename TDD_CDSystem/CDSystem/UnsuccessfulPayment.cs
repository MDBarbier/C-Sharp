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
