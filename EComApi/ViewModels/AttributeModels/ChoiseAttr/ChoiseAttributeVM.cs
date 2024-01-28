using System;

namespace EComApi.ViewModels.AttributeModels.ChoiseAttr
{
    public class ChoiseAttributeVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required List<ChoiseAttributeValueVM> Values { get; set; }
    }
}