namespace GameZone.Data.Config
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(2500).IsRequired();
            builder.Property(x => x.Cover).HasColumnType("VARCHAR").HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
            
        }
    }
}
