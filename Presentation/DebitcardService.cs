using KeyedServiceExample_With_DI.MiddleWare;

namespace KeyedServiceExample_With_DI.Presentation
{
    public class DebitcardService : IEndpoint
    {
        public void MapEndPoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/DebitCard", async () =>
            {
                Console.WriteLine("Debitcard Service");
            });
        }
    }
}
