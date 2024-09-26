namespace GameZone.Settings
{
	public static class FileSettings
	{
		public const string ImagesPath = "/assests/images";
		public const string AllowedExtensions = ".jpg,.jpeg,.png";
		public const int MaxFileSizeInMB = 1;
		public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
		public static Guid guid { get; set; }
	}
}
