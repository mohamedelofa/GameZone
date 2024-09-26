namespace GameZone.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
