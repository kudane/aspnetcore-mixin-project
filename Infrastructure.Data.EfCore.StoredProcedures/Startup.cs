namespace Infrastructure.Data.EfCore.StoredProcedures
{
    public static class Startup
    {
        public static void AddDataStoredProcedure(this IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer("Server=DESKTOP-????;Database=blogging;User ID=???;Password=???");
            });
        }
    }
}
