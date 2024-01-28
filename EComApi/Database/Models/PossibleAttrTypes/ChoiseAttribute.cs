using System;
using EComApi.Database.Models.Enums;
using EComApi.Database.Models.PossibleAttrTypes.PossibleValues;

namespace EComApi.Database.Models.PossibleAttrTypes
{
    public class ChoiseAttribute
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual AttributeType AttributeType { get; set; } = AttributeType.Choise;
        public virtual IEnumerable<PossibleChoiseValue>? Values { get; set; }
    }
}

