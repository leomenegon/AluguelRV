using AluguelRV.Domain.Interfaces.Data;

namespace AluguelRV.Domain.Services;
public class ConfigService
{
    private readonly IConfigData _configData;
    private ResponseHandler _response;

    public ConfigService(IConfigData expenseData)
    {
        _configData=expenseData;
        _response = new ResponseHandler();
    }

    public async Task<ResponseHandler> GetByKey(string key)
    {
        var data = await _configData.GetByKey(key);

        if (data != null)
            _response.Value = data;
        else
            _response.SetAsNotFound();

        return _response;
    }
}
