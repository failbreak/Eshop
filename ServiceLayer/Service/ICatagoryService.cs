using DataLayer.Entities;

namespace ServiceLayer.Service
{
    public interface ICatagoryService
    {
        void AddCategory(string category);
        List<Category> GetCategories();
    }
}