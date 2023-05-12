namespace Infrastructure.Authen.Cookie
{
    internal class CookieIdentityAccessor : ICookieIdentityAccessor
    {
        private readonly IHttpContextAccessor accessor;

        public CookieIdentityAccessor(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public string GetClaim(string claimsConstants)
        {
            var identity = accessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimsConstants);

            if (identity == null)
            {
                throw new Exception("Identity NotFound");
            }

            return identity.Value;
        }
    }
}
