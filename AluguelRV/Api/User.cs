using AluguelRV.Domain;
using AluguelRV.Domain.Dtos;
using AluguelRV.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AluguelRV.Api;

public static class User
{
    [AllowAnonymous]
    public static async Task<IResult> Login(IConfiguration configuration, IUserService userService, LoginRequest loginRequest)
    {
        var response = new ResponseHandler();

        if (!await userService.ValidateCredentials(loginRequest))
        {
            response.SetAsNotFound();
            response.Message = "Login ou senha incorretos.";

            return Api.Response(response);
        }
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Sid, "teste"),
            new Claim(ClaimTypes.NameIdentifier, "teste"),
            new Claim(ClaimTypes.Email, "teste@teste.com")
        };

        var token = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("Jwt:Issuer"),
            audience: configuration.GetValue<string>("Jwt:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(2),
            notBefore: DateTime.UtcNow,
            signingCredentials: new (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key"))), SecurityAlgorithms.HmacSha256)
            );

        response.Value = new JwtSecurityTokenHandler().WriteToken(token);

        return await Task.FromResult(Api.Response(response));
    }

    public static async Task<IResult> Register(IConfiguration configuration, IUserService userService, CreateUserRequest registerRequest)
    {
        var response = await userService.Create(registerRequest);

        if (!response.IsOk())
        {
            response.SetAsNotFound();
            return Api.Response(response);
        }

        return await Login(
            configuration,
            userService,
            new()
            {
                Username = registerRequest.Username,
                Password = registerRequest.Password
            });
    }
}
