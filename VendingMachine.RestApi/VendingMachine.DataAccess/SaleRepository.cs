using VendingMachine.Domain.Abstractions;
using VendingMachine.Domain;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Logic.Exceptions;

namespace VendingMachine.DataAccess.DataAccess
{
    public class SaleRepository : ISaleRepository
    {
        private readonly VendingMachineDbContext dbContext;

        public SaleRepository(VendingMachineDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task Add(Sale sale)
        {
            await dbContext.Sales.AddAsync(sale);
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<Sale>> GetAllByDate(Tuple<DateTime?, DateTime?> dateRange)
        {
            var results = await dbContext.Sales.Where(s => s.Date >= dateRange.Item1 && s.Date <= dateRange.Item2).ToListAsync();
            return results;
        }

        public async Task DeleteByDate(DateTime? startDate, DateTime? endDate)
        {
            if(startDate == default(DateTime) || startDate == null)
            {
                throw new InvalidDateException(startDate);
            }

            if (endDate == default(DateTime) || endDate == null )
            {
                throw new InvalidDateException(startDate);
            }

            dbContext.Sales.RemoveRange(dbContext.Sales.Where(s => s.Date >= startDate && s.Date <= endDate));
            await dbContext.SaveChangesAsync();
        }

    }
}
