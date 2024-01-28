using System;
using EComApi.Database.Models.Enums;
using EComApi.Database.Models.PossibleAttrTypes.PossibleValues;
using EComApi.Database.Models.ProductValues;

namespace EComApi.Database.Models.PossibleAttrTypes
{
    public class TextAttribute
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public AttributeType AttributeType { get; set; } = AttributeType.Text;

        public virtual IEnumerable<TextValue>? TextValues { get; set; }
    }
}

