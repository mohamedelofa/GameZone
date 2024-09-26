
namespace GameZone.Services
{
	public class GamesService : IGamesService
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IMapper _mapper;
		private readonly string _imagesPath;
		public GamesService(AppDbContext context, IWebHostEnvironment webHostEnvironment , IMapper mapper)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			_mapper = mapper;
			_imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
		}


		public IEnumerable<Game> GetAll()
		{
			return _context.Games
				.Include(x => x.Category)
				.Include(x => x.GameDevices)
				.ThenInclude(x => x.Device)
				.AsNoTracking()
				.ToList();
		}

		public Game? GetById(int id)
		{
			return _context.Games
				.Include(x => x.Category)
				.Include(x => x.GameDevices)
				.ThenInclude(x => x.Device)
				.AsNoTracking()
				.SingleOrDefault(x => x.Id == id);
		}

		public async Task Save(CreateGameFormViewModel Game)
		{
			var coverName = await Cover(Game.Cover);
			var game = _mapper.Map<Game>(Game);
			_context.Games.Add(game);
			_context.SaveChanges();
		}

		public async Task<Game?> SaveUpdate(GameUpdateFormViewModel model)
		{
			var game = _context.Games
				.Include(x => x.GameDevices)
				.SingleOrDefault(x => x.Id == model.Id);
			if (game is null)
				return null;
			var oldCover = game.Cover;
			game.Name = model.Name;
			game.Description = model.Description;
			game.GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d}).ToList();
			game.CategoryId = model.CategoryId;
			if(model.Cover is not null)
				game.Cover = await Cover(model.Cover);
			var effectedrows = _context.SaveChanges();
			if(effectedrows > 0)
			{
				if(model.Cover is not null)
				{
					var path = Path.Combine(_imagesPath, oldCover);
					File.Delete(path);
				}
				return game;
			}
			else
			{
				var path = Path.Combine(_imagesPath, game.Cover);
				File.Delete(path);
				return null;
			}
		}


		public bool Delete(int id)
		{
			var isDeleted = false;
			var game = _context.Games.SingleOrDefault(x => x.Id == id);
			if (game is null) return isDeleted;

			var cover = game.Cover;
			_context.Games.Remove(game);
			var effectedRows = _context.SaveChanges();
			if(effectedRows > 0)
			{
				var path = Path.Combine(_imagesPath, cover);
				File.Delete(path);
				isDeleted = true;
			}
			return isDeleted;
		}

		private async Task<string> Cover(IFormFile cover)
		{
			FileSettings.guid = Guid.NewGuid();
			var coverName = $"{FileSettings.guid}{Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_imagesPath, coverName);
			using var stream = File.Create(path);
			await cover.CopyToAsync(stream);
			return coverName;
		}
	}
}
