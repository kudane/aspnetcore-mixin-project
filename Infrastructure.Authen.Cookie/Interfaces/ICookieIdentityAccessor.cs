namespace Infrastructure.Authen.Cookie
{
    public interface ICookieIdentityAccessor
    {
        string GetClaim(string claimsConstants);
    }
}
