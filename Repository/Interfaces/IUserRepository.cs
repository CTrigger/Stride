using Model;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetById(int id);
        public Task<int> Insert(User user);
        public Task<int> Update(User user);
        public Task<int> Delete(int id);


    }
}
