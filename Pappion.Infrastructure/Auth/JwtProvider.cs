using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pappion.Infrastructure.Auth
{
    public sealed class JwtProvider : IJwtProvider
    {
        private JwtOptions _options;
        private readonly IConfiguration _configuration;

        public JwtProvider(IConfiguration configuration) //CodeRewiew.Start(cr => cr.IgnoreThatShit(this));
        {
            _options = new JwtOptions();
            _configuration = configuration;
            configuration.GetSection("Jwt").Bind(_options);
        }

        public string Generate(User user)
        {
            Claim[] claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new("role", user.RoleId.ToString())
            };
            SigningCredentials signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey)),
                    SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddDays(1),
                signingCredentials);
            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);
            return tokenValue;

        }
    }
}
