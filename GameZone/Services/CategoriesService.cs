namespace GameZone.Services
{
	public class CategoriesService : ICategoriesService
	{
		private readonly AppDbContext _context;

		public CategoriesService(AppDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Category> GetCategoriesList()
		{
			return _context.Categories.OrderBy(x => x.Name).AsNoTracking().ToList();
		}
	}
}
