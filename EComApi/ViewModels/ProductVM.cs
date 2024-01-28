using System;
using EComApi.ViewModels.AttributeModels;

namespace EComApi.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required IEnumerable<TextAttributeVM> TextAttributeVMs { get; set; }
    }
}