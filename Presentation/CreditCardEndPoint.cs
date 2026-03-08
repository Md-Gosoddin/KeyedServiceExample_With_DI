using KeyedServiceExample_With_DI.MiddleWare;
using KeyedServiceExample_With_DI.Repositry;

namespace KeyedServiceExample_With_DI.Presentation
{
    public class CreditCardEndPoint : IEndpoint
    {
        public void MapEndPoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/Creditcard", async ([FromKeyedServices(Paymentsystems.SelectedPayment)] IPaymentFactory PaymentFactory) =>
            {
                PaymentFactory.paymentservice(PaymentOption.CreditCard);
                Console.WriteLine($"Credit-Card service");
            });
        }
    }
}
