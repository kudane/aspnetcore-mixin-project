namespace Core.Feature
{
    public static class Startup
    {
        public static void AddCoreFeature(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup), typeof(Core.Feature.Event.Startup));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        }
    }
}