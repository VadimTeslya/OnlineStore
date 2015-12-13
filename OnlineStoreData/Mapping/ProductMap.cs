using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OnlineStoreEntity;

namespace OnlineStoreData.Mapping
{
    public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            HasRequired<Category>(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);

            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Price).HasColumnType("MONEY").IsRequired();
            Property(p => p.ProductPhoto).HasColumnType("IMAGE");
            Property(p => p.Description).HasColumnType("nvarchar(max)");
        }
    }
}
