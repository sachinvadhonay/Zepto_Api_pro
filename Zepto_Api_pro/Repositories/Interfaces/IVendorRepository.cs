using Zepto_Api_pro.Models;

namespace Zepto_Api_pro.Repositories.Interfaces
{
    public interface IVendorRepository
    {
        Task<Vendor> GetVendorIDAsync(int id);
    }
}
