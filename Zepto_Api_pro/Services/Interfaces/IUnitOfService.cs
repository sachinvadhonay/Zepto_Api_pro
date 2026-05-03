using Zepto_Api_pro.Repositories.Interfaces;

namespace Zepto_Api_pro.Services.Interfaces
{
    public interface IUnitOfService
    {
        IProductRepository Products { get; }
        IVendorRepository Vendors {  get; }

        IInventoryRepository Inventory { get; }
        Task SaveProducts();
    }
}
