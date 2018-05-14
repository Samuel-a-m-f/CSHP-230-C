using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository;

namespace LearningCenter.Business
{
    public interface IProductManager
    {
        ProductModel[] ForUser(int userId);
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    //public class ProductManager : IProductManager
    //{
    //    private readonly IProductRepository productRepository;

    //    public ProductManager(IProductRepository productRepository)
    //    {
    //        this.productRepository = productRepository;
    //    }

    //    //public ProductModel[] ForUser(int userId)
    //    //{
    //    //    return productRepository.ForUser(userId).Select(t =>
    //    //                                new ProductModel
    //    //                    {
    //    //                        Id = t.Id,
    //    //                        Name = t.Name,
    //    //                        Description = t.Description,
    //    //                        Price = t.Price
    //    //                    })
    //    //                    .ToArray();
    //    //}
    //}
}
