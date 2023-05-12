namespace Infrastructure.Authen.Cookie
{
    internal class CookieManager : ICookieManager
    {
        private readonly IHttpContextAccessor accessor;

        public CookieManager(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public async Task SignIn(IDictionary<string, string> claimsKeyValue)
        {
            var claims = claimsKeyValue
                .Select(keyvalue => new Claim(keyvalue.Key, keyvalue.Value))
                .ToArray();

            var claimsIdentity = new ClaimsIdentity(claims);

            await accessor.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }

        public async Task SignOut()
        {
            await accessor.HttpContext.SignOutAsync();
        }
    }
}
