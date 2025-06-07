using Backend_ECommerce_App.Models;

namespace API_project.Respostiories
{
    public interface IProductRepository
    {
        public void AddProduct(Product Product);
        public void UpdateProduct(Product Product);
        public void DeleteProduct(int id);
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
    }
}
