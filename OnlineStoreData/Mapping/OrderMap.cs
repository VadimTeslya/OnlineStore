using System.Data.Entity.ModelConfiguration;
using OnlineStoreEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStoreData.Mapping
{
    class OrderMap: EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            HasKey(o => o.Id).Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .Map(mc =>
                {
                    mc.ToTable("OrderJoinProduct");
                    mc.MapLeftKey("OrderId");
                    mc.MapRightKey("ProductId");
                });

            Property(o => o.PhoneNumber).IsRequired();
            Property(o => o.CustomerName).IsRequired().HasMaxLength(100);
            Property(o => o.DeliveryAddress).IsRequired();
            Property(o => o.OrderDate).HasColumnType("datetime2").IsRequired();
        }
    }
}
