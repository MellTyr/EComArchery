using System;
namespace EComApi.Database.Models.PossibleAttrTypes.PossibleValues
{
	public class PossibleChoiseValue
	{
		public int Id { get; set; }
		public string? Value { get; set; }

		public virtual ChoiseAttribute? ChoiseAttribute { get; set; }
		public virtual IEnumerable<Product>? Products { get; set; }
	}
}

