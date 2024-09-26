
namespace GameZone.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(250).IsRequired();

            builder.HasData(new List<Category>
            {
                new Category { Id = 1 , Name = "Sports" },
                new Category { Id = 2 , Name = "Action" },
                new Category { Id = 3 , Name = "Adventure" },
                new Category { Id = 4 , Name = "Racing" },
                new Category { Id = 5 , Name = "Fighting" },
                new Category { Id = 6 , Name = "Film"}
            }); 
        }
    }
}
