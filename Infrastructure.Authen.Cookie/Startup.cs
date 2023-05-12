namespace Infrastructure.Authen.Cookie
{
    public static class Startup
    {
        public static void AddAuthenCookie(this IServiceCollection services, string defaultAuthenticationScheme)
        {
            if (string.IsNullOrEmpty(defaultAuthenticationScheme))
            {
                throw new InvalidOperationException("Default-Scheme For AddAuthentication, Not Setting");
            }

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = defaultAuthenticationScheme ?? CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.Name = SettingConstants.COOKIE_NAME;
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                    options.Cookie.MaxAge = options.ExpireTimeSpan;
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = (context) =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddHttpContextAccessor();
            services.AddSingleton<ICookieManager, CookieManager>();
            services.AddSingleton<ICookieIdentityAccessor, CookieIdentityAccessor>();
        }
    }
}