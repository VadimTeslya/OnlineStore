using System.Data.Entity;

namespace OnlineStoreData.DbInitializer
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext> //IDatabaseInitializer<DataContext>
    {

        /*public void InitializeDatabase(DataContext context)
        {
            context.Database.CreateIfNotExists();
        }*/
    }
}
