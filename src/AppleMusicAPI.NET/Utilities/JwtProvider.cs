using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace AppleMusicAPI.NET.Utilities
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtProviderConfiguration _configuration;

        public JwtProvider(JwtProviderConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            if (string.IsNullOrWhiteSpace(_configuration.KeyId))
                throw new ArgumentException($"{nameof(_configuration.KeyId)} cannot be empty.", nameof(configuration));

            if (string.IsNullOrWhiteSpace(_configuration.TeamId))
                throw new ArgumentException($"{nameof(_configuration.TeamId)} cannot be empty.", nameof(_configuration));

            if (string.IsNullOrWhiteSpace(_configuration.PrivateKeyPath))
                throw new ArgumentException($"{nameof(_configuration.PrivateKeyPath)} cannot be empty.", nameof(_configuration));

            if (!File.Exists(_configuration.PrivateKeyPath))
                throw new FileNotFoundException($"Private Key path {_configuration.PrivateKeyPath} does not exist.");
        }

        public string CreateJwt()
        {
            var key = GetECDsaKey(_configuration.PrivateKeyPath);
            var securityKey = new ECDsaSecurityKey(key) { KeyId = _configuration.KeyId };
            var descriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                Issuer = _configuration.TeamId,
                SigningCredentials = new SigningCredentials(securityKey, "ES256")
            };

            var handler = new JwtSecurityTokenHandler();
            var encodedToken = handler.CreateEncodedJwt(descriptor);
            return encodedToken;
        }

        private static ECDsaCng GetECDsaKey(string privateKeyPath)
        {
            var privateKeyContent = File.ReadAllText(privateKeyPath);
            var privateKeyList = privateKeyContent.Split('\n').ToList();

            // key contains newlines. Only take base 64 encoded string exclude cert header and footer
            var privateKey = privateKeyList
                .Where((s, i) => i != 0 && i != privateKeyList.Count - 1)
                .Aggregate((agg, s) => agg + s);

            return new ECDsaCng(CngKey.Import(Convert.FromBase64String(privateKey), CngKeyBlobFormat.Pkcs8PrivateBlob));
        }
    }
}
