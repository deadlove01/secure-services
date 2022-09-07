using System.IdentityModel.Tokens.Jwt;
using System.Text;
using IdentityServer4.Models;
using Microsoft.IdentityModel.Tokens;
using Movie.API.Helper;

namespace Movie.API.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await AttachAccountToContext(context, token);

        await _next(context);
    }

    private async Task AttachAccountToContext(HttpContext context, string token)
    {
        try
        {

            // var jwtToken = (JwtSecurityToken)validatedToken;
            var accountId = JwtHelper.ValidateToken(token, "secret".Sha256());

            // attach account to context on successful jwt validation
            // context.Items["Account"] = await dataContext.Accounts.FindAsync(accountId);
            context.Items["AccountId"] = accountId;
        }
        catch(Exception ex) 
        {
            Console.WriteLine(ex.Message);
            // do nothing if jwt validation fails
            // account is not attached to context so request won't have access to secure routes
        }
    }
}