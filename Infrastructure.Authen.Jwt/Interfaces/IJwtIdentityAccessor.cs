namespace Infrastructure.Jwt
{
    public interface IJwtIdentityAccessor
    {
        string GetClaim(string claimsConstants);
    }
}
