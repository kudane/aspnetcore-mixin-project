namespace Infrastructure.Data.Constant
{
    public static class Startup
    {
        public static void AddDataConstant(this IServiceCollection services, IConfiguration configuration)
        {
            var mail = new MailSetting();
            configuration.GetSection("Mail").Bind(mail);
            services.AddSingleton(mail);

            var file = new FileSetting();
            configuration.GetSection("File").Bind(file);
            services.AddSingleton(file);
        }
    }
}