using AluguelRV.Api.Dapper.Data;
using AluguelRV.Domain;
using AluguelRV.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AluguelRV.Api;

public static class User
{
    [AllowAnonymous]
    public static async Task<IResult> Login(IConfiguration configuration, UserData userData, LoginRequestDto loginRequest)
    {
        var response = new ResponseHandler();

        if (!await ValidateCredentials(userData, loginRequest))
        {
            response.SetAsNotFound();
            response.Message = "Login ou senha incorretos.";

            return Api.Response(response);
        }

        var claims = new[]
        {
            new Claim("username", "teste"),
            new Claim("role", "user")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")));

        var token = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("Jwt:Issuer"),
            audience: configuration.GetValue<string>("Jwt:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(2),
            notBefore: DateTime.UtcNow,
            signingCredentials: new(key, SecurityAlgorithms.HmacSha256)
            );

        response.Value = new JwtSecurityTokenHandler().WriteToken(token);

        return await Task.FromResult(Api.Response(response));
    }

    //public static async Task<IResult> Register(IConfiguration configuration, IUserService userService, CreateUserRequest registerRequest)
    //{
    //    var response = await userService.Create(registerRequest);

    //    if (!response.IsOk())
    //    {
    //        response.SetAsNotFound();
    //        return Api.Response(response);
    //    }

    //    return await Login(
    //        configuration,
    //        userService,
    //        new()
    //        {
    //            Username = registerRequest.Username,
    //            Password = registerRequest.Password
    //        });
    //}

    private static async Task<bool> ValidateCredentials(UserData userData, LoginRequestDto userDto)
    {
        var user = await userData.GetByUsername(userDto.Username);

        if (user == null)
            return false;

        using var hmac = new HMACSHA512(user.Salt);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));

        return hash.SequenceEqual(user.Password);
    }
}