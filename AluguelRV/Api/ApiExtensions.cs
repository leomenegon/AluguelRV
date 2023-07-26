using AluguelRV.Core;
using AluguelRV.Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace AluguelRV.Api;

public static partial class WebApi
{
    public static IResult CheckNullAndRespond(object? obj)
    {
        var response = new ResponseHandler();

        if (obj == null || obj is IEnumerable<object> e && !e.Any())
            response.SetAsNotFound();
        else response.Value = obj;

        return Response(response);
    }

    public static IResult Response(ResponseHandler response) => response.GetStatus() switch
    {
        HttpStatusCode.OK => Results.Ok(response.Value),
        HttpStatusCode.Created => Results.Created(response.Message, response.Value),
        HttpStatusCode.BadRequest => Results.BadRequest(response),
        HttpStatusCode.Unauthorized => Results.Unauthorized(),
        HttpStatusCode.NotFound => Results.NotFound(response),
        HttpStatusCode.InternalServerError => Results.Problem(),
        _ => Results.NoContent()
    };

    public static IEnumerable<Claim> ExtractClaims(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);

        return securityToken.Claims;
    }

    public static UserDto GetUserFromToken(string jwtToken)
    {
        jwtToken = jwtToken.Replace("Bearer", "").Trim();

        var claims = ExtractClaims(jwtToken);

        var user = new UserDto
        {
            Id = int.Parse(claims.FirstOrDefault(x => x.Type == "userId")?.Value ?? "0"),
            Username = claims.FirstOrDefault(x => x.Type == "username")?.Value ?? string.Empty,
            PersonId = int.Parse(claims.FirstOrDefault(x => x.Type == "personId")?.Value ?? "0"),
            Role = claims.FirstOrDefault(x => x.Type == "role")?.Value ?? "user"
        };

        return user;
    }

    public static UserDto GetUserFromContextOrThrow(IHttpContextAccessor accessor)
    {
        var user = GetUserFromContext(accessor);

        if (user == null)
            throw new UnauthorizedAccessException("Usuário nao encontrado!");

        return user;
    }

    public static UserDto? GetUserFromContext(IHttpContextAccessor accessor)
    {
        var claims = accessor.HttpContext?.User.Claims;

        if (claims == null || !claims.Any())
        {
            var bearer = accessor.HttpContext?.Request.Headers.Authorization.FirstOrDefault();

            if (bearer != null)
                claims = ExtractClaims(bearer);
            else
                return null;
        }

        return MapUserFromClaims(claims);
    }

    public static UserDto? MapUserFromClaims(IEnumerable<Claim> claims)
    {
        if (claims == null || !claims.Any())
            return null;

        var user = new UserDto
        {
            Id = int.Parse(claims.FirstOrDefault(x => x.Type == "userId")?.Value ?? "0"),
            Username = claims.FirstOrDefault(x => x.Type == "username")?.Value ?? claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty,
            PersonId = int.Parse(claims.FirstOrDefault(x => x.Type == "personId")?.Value ?? "0"),
            Role = claims.FirstOrDefault(x => x.Type == "role")?.Value ?? claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? "user"
        };

        return user;
    }
}