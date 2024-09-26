namespace GameZone.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public List<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
        public List<Device> Devices { get; set; } = new List<Device>();

    }
}
