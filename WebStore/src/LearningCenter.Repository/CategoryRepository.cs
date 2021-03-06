﻿using System.Linq;

namespace LearningCenter.Repository
{
    public interface ICategoryRepository
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
    }

    public class CategoryRepository : ICategoryRepository
    {
        public CategoryModel[] Categories
        {
            get
            {
                return DatabaseAccessor.Instance.Classes
                                               .Select(t => new CategoryModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice })
                                               .ToArray();
            }
        }

        public CategoryModel Category(int categoryId)
        {
            var category = DatabaseAccessor.Instance.Classes
                                                   .Where(t => t.ClassId == categoryId)
                                                   .Select(t => new CategoryModel { Id = t.ClassId, Name = t.ClassName, Description = t.ClassDescription, Price = t.ClassPrice })
                                                   .First();
            return category;
        }
    }
}
