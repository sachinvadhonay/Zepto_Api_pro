using Zepto_Api_pro.Data;
using Zepto_Api_pro.Models;
using Zepto_Api_pro.Repositories.Implementations;
using Zepto_Api_pro.Repositories.Interfaces;
using Zepto_Api_pro.Services.Interfaces;

namespace Zepto_Api_pro.Services.Implementations
{
    public class UnitOfService : IUnitOfService
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; }
        public IInventoryRepository Inventory { get; }
        public IVendorRepository Vendors { get; }

        public UnitOfService(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
            Inventory = new InventoryRepository(context);
            Vendors = new VendorRepository(context);
        }

        public async Task SaveProducts()
        {
            await _context.SaveChangesAsync();
        }


    }
}
