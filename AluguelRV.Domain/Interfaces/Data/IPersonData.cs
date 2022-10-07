using AluguelRV.Domain.Models;

namespace AluguelRV.Domain.Interfaces.Data;
public interface IPersonData
{
    Task<PersonModel?> GetById(int id);
    Task<IEnumerable<PersonModel>> GetAll();
}