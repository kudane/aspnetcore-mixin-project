namespace Infrastructure.Jwt
{
    public interface IJwtGenerateToken
    {
        string SignToken(IDictionary<string, string> claimsKeyValue);
        string RefreshToken(IDictionary<string, string> claimsKeyValue);
    }
}
