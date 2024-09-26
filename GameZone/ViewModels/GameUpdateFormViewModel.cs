using GameZone.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
	public class GameUpdateFormViewModel :FormViewModel
	{
		public int Id { get; set; }

		[AllowedExtensions(FileSettings.AllowedExtensions)]
		[MaxFileSize(FileSettings.MaxFileSizeInBytes)]
		public IFormFile? Cover { get; set; } = null!;
		public string? CurrentCover { get; set; }
	}
}
