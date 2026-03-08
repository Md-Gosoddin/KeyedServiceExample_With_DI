using KeyedServiceExample_With_DI.MiddleWare;
using KeyedServiceExample_With_DI.Model;
using Microsoft.Extensions.Options;

namespace KeyedServiceExample_With_DI.Presentation
{
    public class ConfigSettings
    {
    }

    public class Optionclass : IEndpoint
    {
        public void MapEndPoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/optionSetting", async (IOptions<ConfigPayment> optionType) =>
            {
                var currencyType = optionType.Value.CurrencyType;
                return currencyType == null ? null : currencyType;
            });
        }
    }


    public class OptionMonitoring : IEndpoint
    {
        public void MapEndPoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/optionSnapSetting", async (IOptionsSnapshot<ConfigPayment> optionType) =>
            {
                var currencyType = optionType.Value.CurrencyType;
                return currencyType == null ? null : currencyType;
            });
        }
    }
}
