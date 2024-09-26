using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
	public class FormViewModel
	{
		[Required]
		[MaxLength(250)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(2500)]
		public string Description { get; set; } = null!;

		[Display(Name = "Category")]
		public int CategoryId { get; set; }
		public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();

		[Display(Name = "Supported Devices")]
		public List<int> SelectedDevices { get; set; } = null!;
		public IEnumerable<Device> Devices { get; set; } = Enumerable.Empty<Device>();
	}
}
