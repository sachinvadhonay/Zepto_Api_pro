using Microsoft.EntityFrameworkCore;
using Zepto_Api_pro.DTOs;
using Zepto_Api_pro.Models;
using Zepto_Api_pro.Services.Interfaces;

namespace Zepto_Api_pro.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfService _unitOfSevice;

        public ProductService(IUnitOfService unitOfService)
        {
              _unitOfSevice = unitOfService;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _unitOfSevice.Products.RepGetallProductsAsync();

            return products.Select(p => new ProductDto
            {
                ProductID = p.ProductId,
                ProductName = p.Productname,
                Price = p.Price ?? 0,
                Quantity = p.Inventories
                            .Select(i=>i.QuatityAvailable)
                            .FirstOrDefault() ?? 0,
                ImageUrl = p.ImageUrl
            }).ToList();    
        }

        public async Task CreateProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Productname = dto.Productname,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.Now
            };

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName = Guid.NewGuid() + Path.GetExtension(dto.ImageFile.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                product.ImageUrl = "/images/" + fileName;
            }

            await _unitOfSevice.Products.RepAddProduct(product);

            await _unitOfSevice.SaveProducts();


            //getting vendor id and Add to Table 
            var vendor = await _unitOfSevice.Vendors.GetVendorIDAsync(dto.VendorId);

            if (vendor == null)
            {
                throw new Exception("Invalid VendorId");
            }


            //getting inventory id and Add to Table 
            var inventory = new Inventory
            {
                ProductId = product.ProductId,
                VendorId = dto.VendorId,
                QuatityAvailable = dto.Quantity,
                LastUpdated = DateTime.Now
            };

            await _unitOfSevice.Inventory.AddAsync(inventory);

            await _unitOfSevice.SaveProducts();
        }

        public async Task UpdateProduct(UpdateProductDto dto)
        {
            var product = await _unitOfSevice.Products.RepProductGetByIDAsync(dto.ProductId);

            if(product == null)
            {
                throw new Exception("Product Not found");
            }

            var vendor = await _unitOfSevice.Vendors.GetVendorIDAsync(dto.VendorId);

            if (vendor == null)
            {
                throw new Exception("Invalid VendorId");
            }

            product.Productname = dto.Productname;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid() + Path.GetExtension(dto.ImageFile.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }

                product.ImageUrl = "/images/" + fileName;
            }

            var inventory = product.Inventories.FirstOrDefault();

            if(inventory != null)
            {
                inventory.VendorId = dto.VendorId;
                inventory.QuatityAvailable = dto.Quantity;
                inventory.LastUpdated = DateTime.Now;
            }


            await _unitOfSevice.SaveProducts();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _unitOfSevice.Products.RepProductGetByIDAsync(id);

            if(product == null)
            {
                throw new Exception("Product not found");
            }

            if (product.Inventories.Any())
            {
                await _unitOfSevice.Inventory.DeleteRange(product.Inventories.ToList());
            }

            await _unitOfSevice.Products.Delete(product);

            await _unitOfSevice.SaveProducts();

        }


        public async Task<List<ProductDto>> GetProductsByCategory(int categoryId)
        {
            var products = await _unitOfSevice.Products.GetProductByCategoryAsync(categoryId);

            if(products == null || !products.Any())
            {
                throw new Exception("No products found for this category");
            }

            return products.Select(p=> new ProductDto
            {
                ProductID = p.ProductId,
                ProductName = p.Productname,
                Price = p.Price ?? 0,
                ImageUrl = p.ImageUrl,
                Quantity = p.Inventories.FirstOrDefault()?.QuatityAvailable ?? 0
            }).ToList();
                
        }


        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _unitOfSevice.Products.getallcategory();

            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.Categoryname
            }).ToList();
        }
    }
}
