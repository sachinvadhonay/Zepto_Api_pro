using Zepto_Api_pro.Data;
using Zepto_Api_pro.Models;
using Zepto_Api_pro.Repositories.Interfaces;

namespace Zepto_Api_pro.Repositories.Implementations
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _context;

        public VendorRepository(AppDbContext context)
        {
               _context = context;
        }

        public async Task<Vendor> GetVendorIDAsync(int id)
        {
            return await _context.Vendors.FindAsync(id);
        }
    }
}
