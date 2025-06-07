using Backend_ECommerce_App.Models;

namespace APILayer.Services.Admin
{
    public interface IProductAdminService
    {
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productID); 
    }
}
