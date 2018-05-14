//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LearningCenter.Repository
//{
//    public interface IShoppingCartRepository
//    {
//        ShoppingCartModel Add(int userId, int classId);
//        bool Remove(int userId, int classId);
//        ShoppingCartModel[] GetAll(int userId);
//    }

//    public class ShoppingCartModel
//    {
//        public int UserId { get; set; }
//        public int ProductId { get; set; }
//    }

//    public class ShoppingCartRepository : IShoppingCartRepository
//    {
//        public ShoppingCartModel Add(int userId, int classId)
//        {
//            var item = DatabaseAccessor.Instance.UserClass.Add(
//                new LearningCenter.ProductDatabase.Class { ClassId = classId, UserId = userId });

//            DatabaseAccessor.Instance.SaveChanges();

//            return new ShoppingCartModel { UserId = item.UserId, ClassId = item.ProductId };
//        }

//        public ShoppingCartModel[] GetAll(int userId)
//        {
//            var items = DatabaseAccessor.Instance.ShoppingCartItems
//                .Where(t => t.UserId == userId)
//                .Select(t => new ShoppingCartModel { UserId = t.UserId, ProductId = t.ProductId })
//                .ToArray();
//            return items;
//        }

//        public bool Remove(int userId, int productId)
//        {
//            var items = DatabaseAccessor.Instance.ShoppingCartItems
//                                .Where(t => t.UserId == userId && t.ProductId == productId);

//            if (items.Count() == 0)
//            {
//                return false;
//            }

//            DatabaseAccessor.Instance.ShoppingCartItems.Remove(items.First());

//            DatabaseAccessor.Instance.SaveChanges();

//            return true;
//        }
//    }
//}
