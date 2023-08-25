using VendingMachine.Domain.ApiModels;
using VendingMachine.Domain.ApiModels.Requests;

namespace VendingMachine.Domain
{
    public class Mapper
    {
        public static Product ProductApiModelToProductDbModel(CreateOrUpdateProductRequest request)
        {
            return new Product(
                request.Id,
                request.Name,
                request.Price,
                request.Quantity);
        }

        public static ProductDto ProductDbModelToProductApiModel(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }


        public static SaleDto SaleDbModelToSaleApiModel(Sale sale)
        {
            return new SaleDto
            {
                Name = sale.Name,
                Price = sale.Price,
                Date = sale.Date,
                PaymentMethod = sale.PaymentMethod,
            };
        }
    }
}
