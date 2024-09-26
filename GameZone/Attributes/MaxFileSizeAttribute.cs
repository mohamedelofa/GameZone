using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class MaxFileSizeAttribute : ValidationAttribute
	{
		private readonly int _maxFileSize;

		public MaxFileSizeAttribute(int maxFileSize)
		{
			_maxFileSize = maxFileSize;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is null) return null;
			var file = value as IFormFile;
			if (file.Length > _maxFileSize)
			{
				return new ValidationResult($"Maximum allowed size is {_maxFileSize / 1024 / 1024}MB");
			}
			else
				return ValidationResult.Success;

		}
	}
}
