using Zepto_Api_pro.DTOs;

namespace Zepto_Api_pro.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts();

        Task CreateProduct(CreateProductDto dto);
        Task UpdateProduct(UpdateProductDto dto);
        Task DeleteProduct(int id);
        Task<List<ProductDto>> GetProductsByCategory(int categoryId);

        Task<List<CategoryDto>> GetAllCategories();
    }
}
