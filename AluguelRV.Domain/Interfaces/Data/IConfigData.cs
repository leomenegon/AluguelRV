namespace AluguelRV.Domain.Interfaces.Data;

public interface IConfigData
{
    Task<string> GetByKey(string key);
}