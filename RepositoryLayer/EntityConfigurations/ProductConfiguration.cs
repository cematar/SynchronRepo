using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RepositoryLayer.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
            builder.Property(i => i.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(i => i.Category).WithMany(i => i.Products).HasForeignKey(i => i.CategoryId);

            builder.HasData(new Product()
            {
                Id = 1,
                Name = "Samsung 4k Monitor",
                Price =44.3m,
                CategoryId = 1,
                Stock = 200
            }, new Product()
            {
                Id = 2,
                Name = "1 TB Harici Disk USB3.0",
                Price = 14.3m,
                CategoryId = 1,
                Stock = 255
            }, new Product()
            {
                Id = 3,
                Name = "3m optik kablo",
                Price = 14.3m,
                CategoryId = 2,
                Stock = 211
            }
            );

        }
    }
}
