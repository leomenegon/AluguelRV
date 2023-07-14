using AluguelRV.Domain;
using System.Net;

namespace AluguelRV.Api;

public static partial class Api
{
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
}