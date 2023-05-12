namespace Infrastructure.Ldap.Interfaces
{
    public interface IBaseLdapHandle
    {
        bool ValidateCredentials(string username, string password);
    }
}
