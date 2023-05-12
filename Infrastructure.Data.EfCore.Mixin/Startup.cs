namespace Infrastructure.Data.EfCore.Mixin
{
    public static class Startup
    {
        public static void AddDataEfCoreMixin(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer("Server=DESKTOP-????;Database=blogging;User ID=????;Password=????");
            });
        }
    }
}
