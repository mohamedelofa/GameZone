namespace GameZone.Profiles
{
	public class GameCreateProfile : Profile
	{
		public GameCreateProfile()
		{
			CreateMap<CreateGameFormViewModel, Game>()
				.ForMember(dest => dest.Cover, src => src.MapFrom(x => $"{FileSettings.guid}{Path.GetExtension(x.Cover.FileName)}"))
				.ForMember(dest => dest.GameDevices, src => src.MapFrom(x => x.SelectedDevices.Select(g => new GameDevice { DeviceId = g }).ToList()));
		}
	}
}
