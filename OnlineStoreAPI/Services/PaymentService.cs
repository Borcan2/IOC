namespace OnlineStoreAPI.Services
{

    public interface IPaymentService
    {
        string ProcessPayment(string gateway);
    }

    public class PaymentService : IPaymentService
    {
        public string ProcessPayment(string gateway)
        {

            return $"Payment processed using {gateway}";
        }

    }

}