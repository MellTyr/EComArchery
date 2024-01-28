    using EComApi.Database.Models.PossibleAttrTypes.PossibleValues;
using EComApi.Database.Models.ProductValues;

namespace EComApi.Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual required ICollection<PossibleChoiseValue> ChoiseValues { get; set; }
        public virtual required ICollection<TextValue> TextValues { get; set; }
    }
}

            