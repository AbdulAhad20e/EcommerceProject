using API_project.Respostiories;
using Backend_ECommerce_App.Models;

namespace APILayer.Services.Admin
{
    public class ProductAdminService : IProductAdminService
    {
        private readonly IProductRepository _repository;

        public ProductAdminService(IProductRepository r)
        {
            _repository = r;
        }
        public void AddProduct(Product product)
        {
           _repository.AddProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _repository.DeleteProduct(productId);
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }
    }
}
