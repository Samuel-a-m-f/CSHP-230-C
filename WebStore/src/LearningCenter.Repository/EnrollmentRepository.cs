using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Repository
{
    public interface IEnrollmentRepository
    {
        void Add(int userId, int classId);
        List<EnrollmentModel> RegisteredClasses(int userId);

    }

    public class EnrollmentModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public decimal ClassPrice { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }



    class EnrollmentRepository : IEnrollmentRepository
    {
        List<EnrollmentModel> classlist;

        public void Add(int userId, int classId)
        {
            var User = DatabaseAccessor.Instance.Users
                                                   .Where(t => t.UserId == userId)
                                                   .First();

            var Class = DatabaseAccessor.Instance.Classes
                                                   .Where(t => t.ClassId == classId)
                                                   .First();

            User.Classes.Add(Class);

            DatabaseAccessor.Instance.SaveChanges();
        }

        public List<EnrollmentModel> RegisteredClasses(int userId)
        {
            classlist = new List<EnrollmentModel>();

            var User = DatabaseAccessor.Instance.Users
                                                   .Where(t => t.UserId == userId)
                                                   .First();

            foreach (var classToFind in User.Classes)
            {

                classlist.Add(new EnrollmentModel { UserId = User.UserId, ClassId = classToFind.ClassId, ClassPrice = classToFind.ClassPrice, Description = classToFind.ClassDescription, Name = classToFind.ClassName });
            }

            return classlist;
        }
    }
}