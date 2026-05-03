using System.Threading.Tasks;
using Zepto_Api_pro.Models;

namespace Zepto_Api_pro.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> RepGetallProductsAsync();

        Task<Product> RepProductGetByIDAsync(int id);

        Task RepAddProduct(Product product);

        Task Delete(Product product);
    }
}
