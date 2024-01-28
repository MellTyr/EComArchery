using AutoMapper;
using EComApi.Database;
using EComApi.Database.Models;
using EComApi.Database.Models.PossibleAttrTypes;
using EComApi.Database.Models.PossibleAttrTypes.PossibleValues;
using EComApi.Database.Models.ProductValues;
using EComApi.ViewModels;

namespace EComApi.Services.ProductManager
{
    public class ProductManagerService : IProductManagerService
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public ProductManagerService(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ProductVM> GetProducts()
        {
            var p = mapper.ProjectTo<ProductVM>(context.Products);
            return p.ToList();
        }

        public int CreateProduct(ProductVM productVm)
        {
            var product = new Product
            {
                Name = productVm.Name,
                ChoiseValues = new List<PossibleChoiseValue>(),
                TextValues = new List<TextValue>()
            };
            foreach (var textAttr in productVm.TextAttributeVMs)
            {
                if (textAttr.Id == 0)
                {
                    var model = new TextValue
                    {
                        Text = textAttr.Value.Text,
                        TextAttribute = new TextAttribute
                        {
                            AttributeType = Database.Models.Enums.AttributeType.Text,
                            Name = textAttr.Name
                        }
                    };
                    product.TextValues.Add(model);
                }
                else if (textAttr.Id != 0)
                {
                    var attr = context.TextAttributes.Find(textAttr.Id);
                    var model = new TextValue
                    {
                        Text = textAttr.Value.Text,
                        TextAttribute = attr
                    };
                    product.TextValues.Add(model);
                }
            }
            context.Products.Add(product);
            context.SaveChanges();
            return product.Id;
        }
    }
}

