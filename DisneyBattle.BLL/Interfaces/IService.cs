using System.Collections.Generic;
using System.Threading.Tasks;
namespace DisneyBattle.BLL.Interfaces;
public interface IService<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
