using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<int> Insert(Product product);
        public Task<int> Update(Product product);
        public Task<int> Delete(int id);

    }
}
