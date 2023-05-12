namespace Infrastructure.File
{
    public static class Startup
    {
        public static void AddFile(this IServiceCollection services)
        {
            services.AddSingleton<IFileChecker, FileChecker>();
            services.AddSingleton<IFileWriter, FileWriter>();
            services.AddSingleton<IFileReader, FileReader>();
        }
    }
}