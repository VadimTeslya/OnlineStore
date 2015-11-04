using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OnlineStoreEntity;

namespace OnlineStoreData.Mapping
{
    class OrderStatusMap: EntityTypeConfiguration<OrderStatus>
    {
        public OrderStatusMap()
        {
            ToTable("OrderStatus");
            HasKey(o => o.Id).Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(o => o.StatusName).IsRequired();
        }
    }
}
