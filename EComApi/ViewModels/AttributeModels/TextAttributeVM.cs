using System;
namespace EComApi.ViewModels.AttributeModels
{
	public class TextAttributeVM
	{
		public int Id { get; set; }
		public required string Name { get; set; }

		public TextAttributeValueVM? Value { get; set; }
	}
}

