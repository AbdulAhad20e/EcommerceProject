using Backend_ECommerce_App.Models;
using Infrastructure.Respostiories;

namespace APILayer.Services.Admin
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository r)
        {
            _categoryRepository = r;
        }
        public void AddCategory(Category Category)
        {
           _categoryRepository.AddCategory(Category);   
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAllCategorys()
        {
            return _categoryRepository.GetAllCategorys();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }


        public void UpdateCategory(Category Category)
        {
           _categoryRepository.UpdateCategory(Category);
        }
    }
}
