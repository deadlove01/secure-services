using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Movie.API.Helper;

public static class JwtHelper
{
    public static string GenerateJwtToken(Guid payload, string secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", payload.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


    public static string ValidateToken(string token, string secret)
    {
        // var tokenHandler = new JwtSecurityTokenHandler();
        // var key = Encoding.ASCII.GetBytes(secret);
        // try
        // {
        //     tokenHandler.ValidateToken(token, new TokenValidationParameters
        //     {
        //         ValidateIssuerSigningKey = true,
        //         IssuerSigningKey = new SymmetricSecurityKey(key),
        //         ValidateIssuer = false,
        //         ValidateAudience = false,
        //         // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //         ClockSkew = TimeSpan.Zero
        //     }, out SecurityToken validatedToken);
        //
        //     var jwtToken = (JwtSecurityToken)validatedToken;
        //     var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        //
        //     // return account id from JWT token if validation successful
        //     return accountId.ToString();
        // }
        // catch
        // {
        //     // return null if validation fails
        //     return null;
        // }
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        // tokenHandler.ValidateToken(token, new TokenValidationParameters
        // {
        //     ValidateIssuerSigningKey = true,
        //     IssuerSigningKey = new SymmetricSecurityKey(key),
        //     ValidateIssuer = false,
        //     ValidateAudience = false,
        //     // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
        //     ClockSkew = TimeSpan.Zero
        // }, out SecurityToken validatedToken);
        
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateAudience = false,
            
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value).ToString();
        return accountId;
    }
}