using Model;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetById(Guid id);
        public Task<int> Insert(User user);
        public Task<int> Update(User user);
        public Task<int> Delete(Guid id);


    }
}
