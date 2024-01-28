using EComApi.ViewModels;

namespace EComApi.Services.ProductManager
{
    public interface IProductManagerService
    {
        int CreateProduct(ProductVM productVm);
        List<ProductVM> GetProducts();
    }
}