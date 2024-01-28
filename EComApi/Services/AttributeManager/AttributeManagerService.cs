using System;
using AutoMapper;
using EComApi.Database;
using EComApi.Database.Models.PossibleAttrTypes;
using EComApi.ViewModels.AttributeModels;
using EComApi.ViewModels.AttributeModels.ChoiseAttr;

namespace EComApi.Services.AttributeManager
{
    public class AttributeManagerService : IAttributeManagerService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public AttributeManagerService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int CreateChoiseAttribute(ChoiseAttributeVM choiseAttributeVM)
        {
            var m = mapper.Map<ChoiseAttribute>(choiseAttributeVM);

            context.ChoiseAttributes.Add(m);
            context.SaveChanges();
            return m.Id;
        }

        public List<ChoiseAttributeVM> GetChoiseAttribute()
        {
            return mapper.ProjectTo<ChoiseAttributeVM>(context.ChoiseAttributes).ToList();
        }

        public int CreateTextAttribute(TextAttributeVM textAttributeVM)
        {
            var model = mapper.Map<TextAttribute>(textAttributeVM);
            context.TextAttributes.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public List<TextAttributeVM> GetTextAttributeVMs()
        {
            return mapper.ProjectTo<TextAttributeVM>(context.TextAttributes).ToList();
        }
    }
}

