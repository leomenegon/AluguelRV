using AluguelRV.Core;
using System.Net;

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
}