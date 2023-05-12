namespace Infrastructure.Ldap
{
    internal class DirectoryLdap : IDirectoryLdap
    {
        public bool ValidateCredentials(string username, string password)
        {
            // & invalid, check format your company
            using var connection = new DirectoryEntry(DomainConstants.FULL_DOMAIN, $@"your_company & {username}", password);

            if (connection == null)
            {
                // & invalid, check format your company
                throw new Exception($"Directory Connection: NotFound User : your_company & {username}");
            }

            using var searcher = new DirectorySearcher(connection);

            SearchResultCollection result_Searcher;

            result_Searcher = searcher.FindAll();

            return result_Searcher.Count > 0;
        }
    }
}