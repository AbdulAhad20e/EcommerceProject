
using Backend_ECommerce_App.Models;

namespace APILayer.Services.User
{
    public interface IProductUserService
    {
        public List<Product> GetAllProducts();
        public List<Product> SearchProduct(string query);
        public Product GetProductByID(int id);
        public List<Product> GetProductsByCategory(int categoryID);
        public List<Product> GetRecommendedProducts(List<string> userKeywords);

    }
}

