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
