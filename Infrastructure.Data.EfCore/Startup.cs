namespace Infrastructure.Data.EfCore
{
    public static class Startup
    {
        public static void AddDataEfCore(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer("Server=DESKTOP-????;Database=blogging;User ID=???;Password=???");
            });
        }

        //public static void UseConfigureMiddleware(this IApplicationBuilder app)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        var service = context.RequestServices.GetService<BlogContext>();

        //        if (service == null)
        //        {
        //            throw new ArgumentNullException($"{nameof(BlogContext)} Is NULL");
        //        }

        //        using var transaction = service.Database.BeginTransaction();

        //        try
        //        {
        //            await next();

        //            transaction.Commit();
        //        }
        //        catch (Exception)
        //        {
        //            transaction.Rollback();

        //            throw;
        //        }
        //    });
        //}
    }
}
