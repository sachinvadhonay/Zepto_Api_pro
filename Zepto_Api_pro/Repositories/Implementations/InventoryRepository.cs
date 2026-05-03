using Zepto_Api_pro.Data;
using Zepto_Api_pro.Models;
using Zepto_Api_pro.Repositories.Interfaces;

namespace Zepto_Api_pro.Repositories.Implementations
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task AddAsync(Inventory inventory)
        {
            await _context.Inventories.AddAsync(inventory);
        }


        public Task DeleteRange(List<Inventory> inventories)
        {
            _context.Inventories.RemoveRange(inventories);
            return Task.CompletedTask;
        }
         
    }
}
