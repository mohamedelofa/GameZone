using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class AllowedExtensionsAttribute : ValidationAttribute
	{
		private readonly string _allowedExtensions;

		public AllowedExtensionsAttribute(string allowedExtensions)
		{
			_allowedExtensions = allowedExtensions;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is null) return null;
			var file = value as IFormFile;
			var extension = Path.GetExtension(file.FileName);
			if (_allowedExtensions.Split(',').Contains(extension , StringComparer.OrdinalIgnoreCase))
			{
				return ValidationResult.Success;
			}
			return new ValidationResult($"Only {_allowedExtensions} are allowed. ");
		}
	}
}
