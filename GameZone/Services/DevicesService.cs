namespace GameZone.Services
{
	public class DevicesService : IDevicesService
	{
		private readonly AppDbContext _context;
		public DevicesService(AppDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Device> GetDevicesList()
		{
			return _context.Devices.OrderBy(x => x.Name.Length).AsNoTracking().ToList();
		}
	}
}
