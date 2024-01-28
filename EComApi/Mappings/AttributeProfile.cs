using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using EComApi.Database.Models;
using EComApi.Database.Models.Enums;
using EComApi.Database.Models.PossibleAttrTypes;
using EComApi.Database.Models.PossibleAttrTypes.PossibleValues;
using EComApi.Database.Models.ProductValues;
using EComApi.ViewModels;
using EComApi.ViewModels.AttributeModels;
using EComApi.ViewModels.AttributeModels.ChoiseAttr;

namespace EComApi.Mappings
{
    public class AttributeProfile : Profile
    {
        //todo profile front models mappings
        public AttributeProfile()
        {
            CreateMap<TextValue, TextAttributeVM>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.TextAttribute.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.TextAttribute.Name))
                .ForMember(x => x.Value, x => x.MapFrom(y => y));

            CreateMap<TextValue, TextAttributeValueVM>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Text, x => x.MapFrom(y => y.Text));

            CreateMap<TextAttribute, TextAttributeVM>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ReverseMap();

            CreateMap<Product, ProductVM>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.TextAttributeVMs, x => x.MapFrom(y => y.TextValues));

            CreateMap<ChoiseAttributeVM, ChoiseAttribute>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Values, x => x.MapFrom(y => y.Values))
                .ReverseMap();

            CreateMap<ChoiseAttributeValueVM, PossibleChoiseValue>()
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Value, x => x.MapFrom(y => y.Value))
                .ReverseMap();

            CreateMap<AttributeType, AttributeTypeVM>()
                .ConvertUsingEnumMapping();
        }


    }
}

