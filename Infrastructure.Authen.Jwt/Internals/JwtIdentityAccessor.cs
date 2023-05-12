namespace Infrastructure.Jwt
{
    internal class JwtIdentityAccessor : IJwtIdentityAccessor
    {
        private readonly IHttpContextAccessor accessor;

        public JwtIdentityAccessor(IHttpContextAccessor accessor)
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
