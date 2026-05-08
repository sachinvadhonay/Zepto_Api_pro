using Microsoft.EntityFrameworkCore;
using Zepto_Api_pro.Data;
using Zepto_Api_pro.Models;
using Zepto_Api_pro.Repositories.Interfaces;

namespace Zepto_Api_pro.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
                _context = context;
        }

        public async Task<List<Product>> RepGetallProductsAsync()
        {
            return await _context.Products.
                Include(p=> p.Inventories)
                .ToListAsync();
                
        }

        public async Task<Product> RepProductGetByIDAsync(int id)
        {
            return await _context.Products.Include(p => p.Inventories)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task RepAddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<List<Product>> GetProductByCategoryAsync(int categoryId)
        {
            return await _context.Products.Where(p=>p.CategoryId == categoryId)
                .Include(p=>p.Inventories).ToListAsync();
        }

        public async Task<List<ProductCategory>> getallcategory()
        {
             return await _context.ProductCategories.ToListAsync();
        }


        public async Task<List<Vendor>> getallvendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        //public async Task<Product> GetProductByID(int id)
        //{
        //    return await _context.Products.Include(p => p.Inventories)
        //        .FirstOrDefaultAsync(p => p.ProductId == id);
        //}
    }
}
