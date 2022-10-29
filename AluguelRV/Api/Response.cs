using AluguelRV.Domain;

namespace AluguelRV.Api;

public static partial class Api
{
    public static IResult Response(ResponseHandler response) => response.GetStatus() switch
    {
        ResponseStatus.Ok => Results.Ok(response.Value),
        ResponseStatus.Created => Results.Created(response.Message, response.Value),
        ResponseStatus.BadRequest => Results.BadRequest(response),
        ResponseStatus.Unauthorized => Results.Unauthorized(),
        ResponseStatus.NotFound => Results.NotFound(response),
        ResponseStatus.InternalError => Results.Problem(),
        _ => Results.NoContent()
    };

}
