namespace KeyedServiceExample_With_DI.Repositry
{
    public enum PaymentOption
    {
        CreditCard,
        Debitcard,
        UPIPayement,
        Paypal
    }
    public interface IPaymentService
    {
        void Paid();
        PaymentOption PaymentOption { get; }
    }
    public class CreditCard : IPaymentService
    {
        public PaymentOption PaymentOption => PaymentOption.CreditCard;

        public void Paid()
        {
            Console.WriteLine($"Payment Typeof : {PaymentOption}");
        }
    }
    public class DebitCard : IPaymentService
    {
        public PaymentOption PaymentOption => PaymentOption.Debitcard;

        public void Paid()
        {
            Console.WriteLine($"Payment Typeof : {PaymentOption}");
        }
    }
    public interface IPaymentFactory
    {
        IPaymentService paymentservice(PaymentOption paymentOption);
    }
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IEnumerable<IPaymentService> OpaymentServices;
        public PaymentFactory(IEnumerable<IPaymentService> _paymentServices)
        {
            OpaymentServices = _paymentServices;
        }
        public IPaymentService paymentservice(PaymentOption paymentOption)
        {
            var findtype = OpaymentServices.FirstOrDefault(x => x.PaymentOption == paymentOption);
            return findtype ?? throw new NotImplementedException($"Payment type of {paymentOption} is not Found");
        }
    }
}
