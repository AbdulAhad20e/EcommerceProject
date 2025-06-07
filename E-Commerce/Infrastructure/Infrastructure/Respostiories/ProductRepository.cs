using Backend_ECommerce_App.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API_project.Respostiories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebContext _studentDbContext;

        public ProductRepository(WebContext ctxt)
        {
            _studentDbContext = ctxt;
        }
        public void AddProduct(Product Product)
        {
            _studentDbContext.Products.Add(Product);
            _studentDbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product c = GetProductById(id);
            _studentDbContext.Products.Remove(c);
            _studentDbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _studentDbContext.Products.ToList();
        }


        public Product GetProductById(int id)
        {
            return _studentDbContext.Products.Where(f => f.Id == id).ToList().Single();
        }

        public void UpdateProduct(Product Product)
        {
            Product c = GetProductById(Product.Id);
            c.Name = Product.Name;
            _studentDbContext.SaveChanges();

        }
    }
}
