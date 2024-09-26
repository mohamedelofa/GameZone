namespace GameZone.Profiles
{
	public class GameUpdateProfile :Profile
	{
		public GameUpdateProfile()
		{
			CreateMap<Game, GameUpdateFormViewModel>()
				.ForMember(dest => dest.CurrentCover, src => src.MapFrom(x => x.Cover))
				.ForMember(dest => dest.SelectedDevices, src => src.MapFrom(x => x.GameDevices.Select(d => d.DeviceId).ToList()))
				.ForMember(dest => dest.Cover, opt => opt.Ignore());
		}
	}
}
