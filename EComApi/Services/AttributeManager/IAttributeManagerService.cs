using System;
using EComApi.ViewModels.AttributeModels;
using EComApi.ViewModels.AttributeModels.ChoiseAttr;

namespace EComApi.Services.AttributeManager
{
    public interface IAttributeManagerService
    {
        int CreateTextAttribute(TextAttributeVM textAttributeVM);

        int CreateChoiseAttribute(ChoiseAttributeVM choiseAttributeVM);

        List<TextAttributeVM> GetTextAttributeVMs();

        List<ChoiseAttributeVM> GetChoiseAttribute();
    }
}

