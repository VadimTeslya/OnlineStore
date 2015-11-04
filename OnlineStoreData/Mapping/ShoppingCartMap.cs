using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStoreEntity;

namespace OnlineStoreData.Mapping
{
    class ShoppingCartMap: EntityTypeConfiguration<ShoppingСart>
    {
        public ShoppingCartMap()
        {
            ToTable("ShoppingCarts");
            HasKey(s => s.Id).Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.TotalPrice).HasColumnType("money").IsRequired();
        }
        
    }
}
