namespace Infrastructure.Image.Processing
{
    public static class Startup
    {
        public static void AddImageProcessing(this IServiceCollection services)
        {
            services.AddSingleton<IQRCodeCreator, QRCodeCreator>();
            services.AddSingleton<IWebPCreator, WebPCreator>();
        }
    }
}