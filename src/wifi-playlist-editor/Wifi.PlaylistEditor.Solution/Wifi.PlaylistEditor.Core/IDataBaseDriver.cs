using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core
{
    public interface IDataBaseDriver<T> where T : class
    {
        Task CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(string id, T updatedItem);
        Task DeleteAsync(string id);
    }
}