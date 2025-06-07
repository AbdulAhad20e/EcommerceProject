using Backend_ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respostiories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly WebContext _webContext;

        public CategoryRepository(WebContext ctxt)
        {
            _webContext = ctxt;
        }

        public void AddCategory(Category Category)
        {
            _webContext.Categories.Add(Category);
            _webContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            _webContext.Categories.Remove(GetCategoryById(id));
            _webContext.SaveChanges();
        }

        public List<Category> GetAllCategorys()
        {
            return _webContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _webContext.Categories.Where(c => c.CategoryID == id).Single();
        }

        public void UpdateCategory(Category Category)
        {
            _webContext.Categories.Update(Category);
            _webContext.SaveChanges();
        }
    }
}
