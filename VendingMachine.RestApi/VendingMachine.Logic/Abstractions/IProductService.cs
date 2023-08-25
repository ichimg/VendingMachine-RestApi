using VendingMachine.Domain.ApiModels;
using VendingMachine.Domain.ApiModels.Requests;

namespace VendingMachine.Domain.Abstractions
{
    public interface IProductService
    {
        Task CreateProduct(CreateOrUpdateProductRequest request);
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task UpdateProduct(int authorId, CreateOrUpdateProductRequest request);
        Task DeleteProduct(int productId);
    }
}