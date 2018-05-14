using System.Linq;
using LearningCenter.Repository;

namespace LearningCenter.Business
{
    public interface ICategoryManager
    {
        CategoryModel[] Categories { get; }
        CategoryModel Category(int categoryId);
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CategoryModel(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoryModel[] Categories
        {
            get
            {
                return categoryRepository.Categories
                                            .Select(t => new CategoryModel(t.Id, t.Name, t.Description, t.Price))
                                            .ToArray();
            }
        }

        public CategoryModel Category(int categoryId)
        {
            var categoryModel = categoryRepository.Category(categoryId);
            return new CategoryModel(categoryModel.Id, categoryModel.Name, categoryModel.Description, categoryModel.Price);
        }
    }
}
