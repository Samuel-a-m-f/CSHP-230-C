using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public interface IProductRepository
    {
        ProductModel[] ForClass(int classId);
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }

    //public class ProductRepository : IProductRepository
    //{
    //    public ProductModel[] ForClass(int classId)
    //    {
    //        return DatabaseAccessor.Instance.Classes.First(t => t.ClassId == classId)
    //                              .ClassName.Select(t => new ProductModel
    //                              {
    //                                  Id = t.ClassId,
    //                                  Name = t.ClassName,
    //                                  Description = t.ClassDescription,
    //                                  Price = t.ClassPrice
    //                              })
    //        .ToArray();
    //    }
    //}
}
