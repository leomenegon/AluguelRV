using AluguelRV.Api.Dapper.Data;
using AluguelRV.Core;
using AluguelRV.Shared.Dtos;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AluguelRV.Api.Api;

public static class User
{
    [AllowAnonymous]
    public static async Task<IResult> Login(IConfiguration configuration, UserData userData, PersonData personData, LoginRequestDto loginRequest)
    {
        var response = new ResponseHandler();

        var user = await ValidateCredentials(userData, loginRequest);

        if (user == null)
        {
            response.SetAsNotFound("Login ou senha incorretos.");

            return WebApi.Response(response);
        }

        var person = await personData.GetById(user.PersonId);

        var claims = new[]
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("personId", user.PersonId.ToString()),
            new Claim("username", user.Username),
            new Claim("name", person?.Name ?? string.Empty),
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

        return await Task.FromResult(WebApi.Response(response));
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

    private static async Task<UserDto?> ValidateCredentials(UserData userData, LoginRequestDto loginDto)
    {
        var user = await userData.GetByUsername(loginDto.Username);

        if (user == null)
            return null;

        using var hmac = new HMACSHA512(user.Salt);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        if (hash.SequenceEqual(user.Password))
            return user.Adapt<UserDto>();

        return null;
    }
}