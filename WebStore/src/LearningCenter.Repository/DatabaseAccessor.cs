using LearningCenter.ProductDatabase;

namespace LearningCenter.Repository
{
    public class DatabaseAccessor
    {
        private static readonly Entities4 entities;

        static DatabaseAccessor()
        {
            entities = new Entities4();
            entities.Database.Connection.Open();
        }

        public static Entities4 Instance
        {
            get
            {
                return entities;
            }
        }
    }
}