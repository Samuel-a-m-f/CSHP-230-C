//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using LearningCenter.Repository;

//namespace LearningCenter.Business
//{
//    public interface IShoppingCartManager
//    {
//        ShoppingCartModel Add(int userId, int productId);
//        bool Remove(int userId, int productId);
//        ShoppingCartModel[] GetAll(int userId);
//    }

//    public class ShoppingCartModel
//    {
//        public int UserId { get; set; }
//        public int ProductId { get; set; }
//    }

//    public class ShoppingCartManager : IShoppingCartManager
//    {
//        private readonly IShoppingCartRepository shoppingCartRepository;

//        public ShoppingCartManager(IShoppingCartRepository shoppingCartRepository)
//        {
//            this.shoppingCartRepository = shoppingCartRepository;
//        }

//        public ShoppingCartModel Add(int userId, int productId, int quantity)
//        {
//            var item = shoppingCartRepository.Add(userId, productId, quantity);

//            return new ShoppingCartModel { ProductId = item.ProductId, UserId = item.UserId };
//        }

//        public ShoppingCartModel[] GetAll(int userId)
//        {
//            var items = shoppingCartRepository.GetAll(userId)
//                .Select(t => new ShoppingCartModel { UserId = t.UserId, ProductId = t.ProductId })
//                .ToArray();

//            return items;
//        }

//        public bool Remove(int userId, int productId)
//        {
//            return shoppingCartRepository.Remove(userId, productId);
//        }
//    }
//}
