namespace Infrastructure.Ldap
{
    public static class Startup
    {
        public static void AddAuthenLdap(this IServiceCollection services)
        {
            services.AddSingleton<IDirectoryLdap, DirectoryLdap>();
            services.AddSingleton<INovellLdap, NovellLdap>();
            services.AddSingleton<IPrincipalContextLdap, PrincipalContextLdap>();
        }
    }
}
