using VendingMachine.Domain;
using VendingMachine.Domain.Abstractions;
using VendingMachine.Domain.ApiModels;
using VendingMachine.Logic.Abstractions;

namespace VendingMachine.Logic
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository repository;

        public SaleService(ISaleRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<SaleDto>> GetSales(DateTime? startDate, DateTime? endDate)
        {
            List<SaleDto> results = new List<SaleDto>();
            List<Sale> salesFromDb = await repository.GetAllByDate(new Tuple<DateTime?, DateTime?>(startDate, endDate));

            salesFromDb.ForEach(s => results.Add(Mapper.SaleDbModelToSaleApiModel(s)));

            return results;
        }

        public async Task DeleteSales(DateTime? startDate, DateTime? endDate)
        {
            await repository.DeleteByDate(startDate, endDate);
        }
    }
}
