using Backend_ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respostiories
{
    public interface ICategoryRepository
    {
        public void AddCategory(Category Category);
        public void UpdateCategory(Category Category);
        public void DeleteCategory(int id);
        public List<Category> GetAllCategorys();
        public Category GetCategoryById(int id);
    }
}
