using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RepositoryLayer.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.HasData(new Category() {
                Id=1,
                Name="Elektronik"
            },
            new Category()
            {
                Id = 2,
                Name = "Sarf Malzeme"
            });
           
        }
    }
}
