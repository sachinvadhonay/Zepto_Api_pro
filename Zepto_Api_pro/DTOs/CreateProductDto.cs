namespace Zepto_Api_pro.DTOs
{
    public class CreateProductDto
    {
        public string Productname { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }   
        public int VendorId { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
