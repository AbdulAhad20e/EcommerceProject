
using API_project.Respostiories;
using Backend_ECommerce_App.Models;

namespace APILayer.Services.User
{
    public class ProductUserService : IProductUserService
    {
        private readonly IProductRepository _repository;
        public ProductUserService(IProductRepository r)
        {
            _repository = r;
        }
        public List<Product> GetProductsByCategory(int categoryID)
        {
            return _repository.GetAllProducts().Where(p => p.CategoryID == categoryID).ToList();
        }


        public List<Product> SearchProduct(string query)
        {
            return _repository.GetAllProducts().Where(s => s.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || s.Description.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }


        public List<Product> GetRecommendedProducts(List<string> p)
        {
            List<Product> FinalList = new List<Product>();
            foreach (string item in p)
            {
                List<Product> products = SearchProduct(item);
                FinalList.AddRange(products);
            }

            return FinalList;
        }



        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Product GetProductByID(int id)
        {
            return _repository.GetProductById(id);
        }
    }
}
