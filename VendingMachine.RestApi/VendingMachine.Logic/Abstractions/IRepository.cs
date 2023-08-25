using System.Threading.Tasks;

namespace VendingMachine.Domain.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetByColumn(int shelfNumber);
        Task Add(T product);
        Task Update(int id, T product);
        Task Delete(int id);

    }
}