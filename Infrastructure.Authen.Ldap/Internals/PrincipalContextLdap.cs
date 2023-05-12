namespace Infrastructure.Ldap
{
    internal class PrincipalContextLdap : IPrincipalContextLdap
    {
        public bool ValidateCredentials(string username, string password)
        {
            using var connection = new PrincipalContext(ContextType.Domain, DomainConstants.SHORT_DOMAIN);

            if (connection == null)
            {
                throw new Exception($"Principal Context Connection : NotFound User : {username}");
            }

            return connection.ValidateCredentials(username, password);
        }
    }
}