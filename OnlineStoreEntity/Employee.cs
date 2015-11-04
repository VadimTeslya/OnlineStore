using System.IO;

namespace OnlineStoreEntity
{
    public class Employee: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
    }
}
