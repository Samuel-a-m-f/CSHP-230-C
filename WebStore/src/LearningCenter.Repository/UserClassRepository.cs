using System.Linq;

namespace LearningCenter.Repository
{
    public interface IUserClassRepository
    {
        UserClassModel Add(int userId, int classId);
        bool Remove(int userId, int classId);
        UserClassModel[] GetAll(int userId);
    }

    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }

    //public void Add(int userId, int classId)
    //{
    //    var user = GetUser(userId);

    //    var class_info = GetClass(classId);

    //    user.Classes.Add(new LearningCenter.Database.Class
    //    {
    //        ClassId = class_info.Id,
    //        ClassName = class_info.Name,
    //        ClassDescription = class_info.Description,
    //        ClassPrice = class_info.Price
    //    });
    //    DatabaseAccessor.Instance.SaveChanges();

    //}

    //private ClassListModel GetClass(int classId)
    //{

    //    var class_info = DatabaseAccessor.Instance.Classes
    //    .FirstOrDefault(t => t.ClassId == classId);

    //    return new ClassListModel { Id = class_info.ClassId, Name = class_info.ClassName, Description = class_info.ClassDescription, Price = class_info.ClassPrice };
    //}

    //private UserModel GetUser(int userId)
    //{
    //    var user_info = DatabaseAccessor.Instance.Users
    //    .FirstOrDefault(t => t.UserId == userId);

    //    return new UserModel { Id = user_info.UserId, Name = user_info.UserEmail, Classes = user_info.Classes };
    //}

    //public class UserClassRepository : IUserClassRepository
    //{
    //    public UserClassModel Add(int userId, int classId)
    //    {
    //        var item = DatabaseAccessor.Instance.Users.Add(
    //            new LearningCenter.ProductDatabase.Class { ClassId = classId, UserId = userId });
    //        var item = DatabaseAccessor.Instance.UserClasses.Add(
    //            new LearningCenter.ProductDatabase.UserClass { ClassId = classId, UserId = userId });

    //        DatabaseAccessor.Instance.SaveChanges();

    //        return new UserClassModel { UserId = item.UserId, ClassId = item.ClassId };
    //    }

    //    public UserClassModel[] GetAll(int userId)
    //    {
    //        var items = DatabaseAccessor.Instance.UserClasses
    //            .Where(t => t.UserId == userId)
    //            .Select(t => new UserClassModel { UserId = t.UserId, ClassId = t.ClassId })
    //            .ToArray();
    //        return items;
    //    }

    //    public bool Remove(int userId, int classId)
    //    {
    //        var items = DatabaseAccessor.Instance.UserClasses
    //                            .Where(t => t.UserId == userId && t.ClassId == classId);

    //        if (items.Count() == 0)
    //        {
    //            return false;
    //        }

    //        DatabaseAccessor.Instance.UserClasses.Remove(items.First());

    //        DatabaseAccessor.Instance.SaveChanges();

    //        return true;
    //    }
    //}
}
