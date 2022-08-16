using Model;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetById(uint id);
        public Task<User> Insert(User user);
        public Task<User> Update(User user);
        public Task<int> Delete(uint id);
        public Task<User> UpdatePassword(string email, string password);


    }
}
