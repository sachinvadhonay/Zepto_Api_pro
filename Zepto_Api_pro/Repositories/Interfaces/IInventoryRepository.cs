using Zepto_Api_pro.Models;

namespace Zepto_Api_pro.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        Task AddAsync(Inventory inventory);
        Task DeleteRange(List<Inventory> inventories);
    }
}
