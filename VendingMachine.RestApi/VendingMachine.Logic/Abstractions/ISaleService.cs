using VendingMachine.Domain.ApiModels;

namespace VendingMachine.Logic.Abstractions
{
    public interface ISaleService
    {
        Task DeleteSales(DateTime? startDate, DateTime? endDate);
        Task<List<SaleDto>> GetSales(DateTime? startDate, DateTime? endDate);
    }
}