namespace Infrastructure.Jwt
{
    public static class Startup
    {
        public static void AddAuthenJwt(this IServiceCollection services, string defaultAuthenticationScheme)
        {
            if (string.IsNullOrEmpty(defaultAuthenticationScheme))
            {
                throw new InvalidOperationException("Default-Scheme For AddAuthentication, Not Setting");
            }

            var key = Encoding.ASCII.GetBytes(SettingConstants.JWT_SECRET_KEY);

            services
                .AddAuthentication(config =>
                {
                    config.DefaultScheme = defaultAuthenticationScheme ?? JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.RequireHttpsMetadata = false;
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            services.AddHttpContextAccessor();
            services.AddSingleton<IJwtGenerateToken, JwtGenerateToken>();
            services.AddSingleton<IJwtIdentityAccessor, JwtIdentityAccessor>();
        }
    }
}
