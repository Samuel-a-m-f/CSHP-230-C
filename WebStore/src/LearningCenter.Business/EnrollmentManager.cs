using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningCenter.Repository;

namespace LearningCenter.Business
{

    public interface IEnrollmentManager
    {
        void Add(int userId, int classId);
        List<EnrollmentModel> GetAll(int userId);

    }

    public class EnrollmentModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public decimal ClassPrice { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }


    class EnrollmentManager : IEnrollmentManager
    {

        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }


        public void Add(int userId, int classId)
        {
            enrollmentRepository.Add(userId, classId);
        }


        // Finding all classes a user is registered for
        public List<EnrollmentModel> GetAll(int userId)
        {
            var all = enrollmentRepository.RegisteredClasses(userId)
                .Select(t => new EnrollmentModel { ClassId = t.ClassId, UserId = t.UserId, ClassPrice = t.ClassPrice, Description = t.Description, Name = t.Name }).ToList();
            return all;
        }
    }
}
