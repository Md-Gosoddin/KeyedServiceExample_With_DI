namespace KeyedServiceExample_With_DI.MiddleWare
{
    public interface IEndpoint
    {
        void MapEndPoint(IEndpointRouteBuilder app);
    }

    public static class MapEndPoint
    {

        public static void MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            //!t.IsInterface	Exclude the Interface itself.
            //!t.IsAbstract	Exclude Incomplete Classes that can't be created.
            var endpointDiscovery = typeof(IEndpoint).Assembly.GetTypes()
                .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var type in endpointDiscovery)
            {
                var endpoint = (IEndpoint)Activator.CreateInstance(type)!;
                endpoint.MapEndPoint(app);
            }
        }
    }
}
