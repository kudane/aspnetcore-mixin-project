namespace Infrastructure.Jwt
{
    internal class JwtGenerateToken : IJwtGenerateToken
    {
        public string SignToken(IDictionary<string, string> claimsKeyValue)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(SettingConstants.JWT_SECRET_KEY);

            var claims = claimsKeyValue
                .Select(keyvalue => new Claim(keyvalue.Key, keyvalue.Value))
                .ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(SettingConstants.EXPIRED_IN_HOURS),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string RefreshToken(IDictionary<string, string> claimsKeyValue)
        {
            throw new NotImplementedException();
        }
    }
}
