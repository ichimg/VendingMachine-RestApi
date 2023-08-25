using VendingMachine.Domain.Abstractions;
using VendingMachine.Domain.ApiModels;
using VendingMachine.Domain.ApiModels.Requests;

namespace VendingMachine.Domain
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;

        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task CreateProduct(CreateOrUpdateProductRequest request)
        {
            Product product = Mapper.ProductApiModelToProductDbModel(request);

            await repository.Add(product);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            List<ProductDto> resultedProducts = new List<ProductDto>();
            List<Product> productsFromDb = await repository.GetAll();

            productsFromDb.ForEach(x => resultedProducts.Add(Mapper.ProductDbModelToProductApiModel(x)));

            return resultedProducts;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product productFromDb = await repository.GetByColumn(productId);

            ProductDto productDto = Mapper.ProductDbModelToProductApiModel(productFromDb);

            return productDto;
        }

        public async Task UpdateProduct(int authorId, CreateOrUpdateProductRequest request)
        {
            Product product = Mapper.ProductApiModelToProductDbModel(request);

            await repository.Update(authorId, product);
        }

        public async Task DeleteProduct(int productId)
        {
            await repository.Delete(productId);
        }

    }
}
