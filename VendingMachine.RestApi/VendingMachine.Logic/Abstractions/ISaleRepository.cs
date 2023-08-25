namespace VendingMachine.Domain.Abstractions
{
    public interface ISaleRepository
    {
        Task Add(Sale sale);
        Task<List<Sale>> GetAllByDate(Tuple<DateTime?, DateTime?> dateRange);
        Task DeleteByDate(DateTime? startDate, DateTime? endDate);
    }
}
