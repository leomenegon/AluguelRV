using System.Net;

namespace AluguelRV.Domain;
public class ResponseHandler
{
    private ResponseModel _response;

    public string Message
    {
        get => _response.Message;
        set => _response.Message = value;
    }

    public dynamic? Value
    {
        get => _response.Value;
        set => _response.Value = value;
    }

    public ResponseHandler()
    {
        _response = new ResponseModel();
    }

    public ResponseHandler(string message)
    {
        _response = new ResponseModel() { Message = message };
    }

    public ResponseHandler(dynamic value)
    {
        _response = new ResponseModel() { Value = value };
    }

    public ResponseHandler(string message, dynamic value)
    {
        _response = new ResponseModel() { Message = message, Value = value };
    }

    public void SetAsNotFound()
    {
        _response.Message = "Registro(s) não encontrado(s)";
        _response.Status = HttpStatusCode.NotFound;
        _response.Ok = false;
    }

    public void SetBadRequest(string message)
    {
        _response.Message = message;
        _response.Status = HttpStatusCode.BadRequest;
        _response.Ok = false;
    }

    public bool IsOk()
        => _response.Ok;

    public HttpStatusCode GetStatus()
        => _response.Status;
}

internal class ResponseModel
{
    public string Message { get; set; } = "Ok!";
    public dynamic? Value { get; set; }
    public bool Ok { get; set; } = true;
    public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
}