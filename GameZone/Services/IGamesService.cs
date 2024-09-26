namespace GameZone.Services
{
	public interface IGamesService
	{
		Task Save(CreateGameFormViewModel Game);
		IEnumerable<Game> GetAll();
		Game? GetById(int id);
		Task<Game?> SaveUpdate(GameUpdateFormViewModel model);

		bool Delete(int id);
	}
}
