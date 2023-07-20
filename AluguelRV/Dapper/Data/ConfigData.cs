using AluguelRV.Api.Dapper.DbAccess;
using AluguelRV.Shared.ViewModels;

namespace AluguelRV.Api.Dapper.Data;
public class ConfigData
{
    private readonly DataAccess _db;

    public ConfigData(DataAccess db)
    {
        _db=db;
    }
    public async Task<string> GetByKey(string key)
    {
        var query = await _db.LoadData<ConfigValueViewModel, dynamic>("dbo.spConfig_Get", new {Key = key});

        if (query.Any())
            return query.First().Value;

        return string.Empty;
    }
}