using Backend_ECommerce_App.Models;

namespace APILayer.Services.Admin
{
    public interface ICategoryService
    {
        public void AddCategory(Category Category);
        public void UpdateCategory(Category Category);
        public void DeleteCategory(int id);
        public List<Category> GetAllCategorys();
        public Category GetCategoryById(int id);



    }

}
