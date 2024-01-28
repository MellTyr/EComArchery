using System;
using EComApi.Database.Models.PossibleAttrTypes;

namespace EComApi.Database.Models.ProductValues
{
	public class TextValue
	{
		public int Id { get; set; }
		public string? Text { get; set; }
		public int ProductId { get; set; }
		public int TextAttributeId { get; set; }
		public virtual TextAttribute? TextAttribute { get; set; }
		public virtual Product? Product { get; set; }
	}
}

