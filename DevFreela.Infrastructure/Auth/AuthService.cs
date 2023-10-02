using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _securityKey;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        _tokenHandler = new JwtSecurityTokenHandler();
    }


    public string GenerateJwtToken(string email, string role)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
        {
            throw new ArgumentException("Email and role must not be empty");
        }

        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);


        var claims = new List<Claim>
        {
            new Claim("userName", email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials,
            claims: claims);

        return _tokenHandler.WriteToken(token);
    }

    public string ComputeSha256Hash(string password)
    {
        using var sha256Hash = SHA256.Create();
       
        // ComputeHash - retorna byte array  
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        // Converte byte array para string   
        var builder = new StringBuilder();

        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
        }
        
        // for (var i = 0; i < bytes.Length; i++)
        // {
        //     builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
        // }

        return builder.ToString();
    }
}