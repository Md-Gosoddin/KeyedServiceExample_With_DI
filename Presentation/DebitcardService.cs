using KeyedServiceExample_With_DI.MiddleWare;
using KeyedServiceExample_With_DI.Repositry;

namespace KeyedServiceExample_With_DI.Presentation
{
    public class DebitcardService : IEndpoint
    {
        public void MapEndPoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/DebitCard", async ([FromKeyedServices(Paymentsystems.SelectedPayment)] IPaymentFactory PaymentFactory) =>
            {
                PaymentFactory.paymentservice(PaymentOption.Debitcard);
                Console.WriteLine("Debitcard Service");
            });
        }
    }
}
