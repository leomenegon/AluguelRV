using AluguelRV.Domain.Interfaces;
using AluguelRV.Domain.Interfaces.Data;
using AluguelRV.Domain.ViewModels;
using Dapper;
using System.Data;

namespace AluguelRV.Repository.Data;
public class ConfigData : IConfigData
{
    private readonly IDataAccess _db;

    public ConfigData(IDataAccess db)
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
