namespace GameZone.Data.Config
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Icon).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Games)
                .WithMany(x => x.Devices)
                .UsingEntity<GameDevice>(
                    r => r.HasOne(x => x.Game).WithMany(x => x.GameDevices).HasForeignKey(x => x.GameId),
                    l => l.HasOne(x => x.Device).WithMany(x => x.GameDevices).HasForeignKey(x => x.DeviceId)
                    );
            builder.HasData(new List<Device>
            {
                new Device {Id = 1 , Name = "PlayStation" , Icon = "bi bi-playstation"},
                new Device {Id = 2 , Name = "Xbox" , Icon = "bi bi-xbox" },
                new Device {Id = 3 , Name = "Nintendo Switch" , Icon = "bi bi-nintendo-switch" },
                new Device {Id = 4 , Name = "PC" , Icon = "bi bi-pc-display-horizontal" }
            });
        }
    }
}
