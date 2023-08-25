using VendingMachine.Domain.Abstractions;
using VendingMachine.Domain;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Logic.Exceptions;

namespace VendingMachine.DataAccess.DataAccess
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly VendingMachineDbContext dbContext;

        public ProductRepository(VendingMachineDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            //Add(new Product(1, "chocolate bar", 1.55f, 5));
            //Add(new Product(2, "orange juice", 3.25f, 3));
            //Add(new Product(3, "energy drink", 4.55f, 2));
        }

        public async Task<List<Product>> GetAll()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByColumn(int shelfNumber)
        {
            Product product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == shelfNumber);

            if (product == null)
            {
                throw new InvalidColumnException(shelfNumber);
            }

            return product;
        }

        public async Task Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

           await dbContext.Products.AddAsync(product);
           await dbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Product product)
        {
            Product productFromDb = await GetByColumn(id);

            productFromDb.Id = product.Id;
            productFromDb.Name = product.Name;
            productFromDb.Price = product.Price;
            productFromDb.Quantity = product.Quantity;
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Product product = await GetByColumn(id);

            if (product == null)
            {
                throw new InvalidColumnException(id);
            }

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
