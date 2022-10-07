namespace AluguelRV.Domain.Interfaces;

public interface IDataAccess
{
    Task ExecuteCommand<T>(string storedProcedure, T parameters, string connectionId = "Default");
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
}