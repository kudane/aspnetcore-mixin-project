namespace Infrastructure.Authen.Cookie
{
    public interface ICookieManager
    {
        Task SignIn(IDictionary<string, string> claimsKeyValue);
        Task SignOut();
    }
}
