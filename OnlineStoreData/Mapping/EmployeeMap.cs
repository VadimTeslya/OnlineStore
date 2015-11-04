using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OnlineStoreEntity;

namespace OnlineStoreData.Mapping
{
    class EmployeeMap: EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employees");
            HasKey(e => e.Id).Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name).IsRequired();
            Property(e => e.SecondName).IsRequired();
            Property(e => e.Position).IsRequired();
        }
    }
}
