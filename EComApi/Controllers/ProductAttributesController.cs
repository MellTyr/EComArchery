using AutoMapper;
using EComApi.Database;
using EComApi.Services.AttributeManager;
using EComApi.ViewModels.AttributeModels;
using EComApi.ViewModels.AttributeModels.ChoiseAttr;
using Microsoft.AspNetCore.Mvc;

namespace EComApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributesController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IAttributeManagerService attributeManagerService;

        public ProductAttributesController(ApplicationContext context,
            IMapper mapper,
            IAttributeManagerService attributeManagerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.attributeManagerService = attributeManagerService;
        }

        [HttpGet("GetChoiseAttributes")]
        public IActionResult GetAttributes()
        {
            return Ok(attributeManagerService.GetChoiseAttribute());
        }

        [HttpPost("CreateChoiseAttribute")]
        public IActionResult CreateAttribute(ChoiseAttributeVM choiseAttribute)
        {
            return Ok(attributeManagerService.CreateChoiseAttribute(choiseAttribute));
        }

        [HttpPost("CreateTextAttribute")]
        public IActionResult CreateTextAttribute(TextAttributeVM textAttributeVM)
        {
            return Ok(attributeManagerService.CreateTextAttribute(textAttributeVM));
        }

        [HttpGet("GetTextAttributes")]
        public IActionResult GetTextAttributes()
        {
            return Ok(attributeManagerService.GetTextAttributeVMs());
        }
    }
}
