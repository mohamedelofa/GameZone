using GameZone.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
	public class CreateGameFormViewModel :FormViewModel
	{
		[Required]
		[AllowedExtensions(FileSettings.AllowedExtensions)]
		[MaxFileSize(FileSettings.MaxFileSizeInBytes)]
		public IFormFile Cover { get; set; } = null!;
	}
}
