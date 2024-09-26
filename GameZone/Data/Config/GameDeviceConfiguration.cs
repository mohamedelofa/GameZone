
namespace GameZone.Data.Config
{
    public class GameDeviceConfiguration : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(x => new {x.GameId,x.DeviceId});
        }
    }
}
