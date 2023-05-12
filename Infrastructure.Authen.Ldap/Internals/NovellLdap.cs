namespace Infrastructure.Ldap
{
    internal class NovellLdap : INovellLdap
    {
        public bool ValidateCredentials(string username, string password)
        {
            using var connection = new LdapConnection() { SecureSocketLayer = false };

            if (connection == null)
            {
                throw new Exception($"Novell Connection : NotFound User : {username}");
            }

            try
            {
                connection.Connect(DomainConstants.SHORT_DOMAIN, LdapConnection.DefaultPort);

                // & invalid, check format your company
                connection.Bind($"{username} & {DomainConstants.SHORT_DOMAIN}", password);

                return connection.Bound;
            }
            catch (Exception ex)
            {
                throw new LdapException(ex.Message);
            }
        }
    }
}