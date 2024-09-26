namespace GameZone.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public List<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
