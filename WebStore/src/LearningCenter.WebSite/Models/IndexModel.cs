using System.Collections.Generic;

namespace LearningCenter.WebSite.Models
{
    public class IndexModel
    {
        public CategoryModel[] Categories { get; set; }

        public string classToAdd { get; set; }
        public List<EnrollmentModel> registeredClasses { get; set; }
        public UserModel user { get; set; }
    }
}