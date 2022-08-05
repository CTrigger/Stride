using Model;
using Model.Enum;
using Repository.Context;
using Repository.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        #region variables
        private readonly UserContext _userContext;
        #endregion

        #region ctor
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        #endregion

        #region Methods
        public async Task<User> GetById(Guid id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task<User> Insert(User user)
        {
            try
            {
                await _userContext.Users.AddAsync(user);
                if (await _userContext.SaveChangesAsync() > 0)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Cannot add user");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> Update(User user)
        {
            User update = await _userContext.Users.FindAsync(user.Id);
            if (update == null)
            {
                throw new Exception("Not Found");
            }
            else
            {
                update.Email = user.Email;
                update.Name = user.Name;
                update.LastName = user.LastName;
                update.Password = user.Password;
                try
                {
                    if (await _userContext.SaveChangesAsync() > 0)
                    {
                        return update;
                    }
                    else
                    {
                        throw new Exception("Register unchanged");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task<int> Delete(Guid id)
        {
            User delete = await _userContext.Users.FindAsync(id);
            if (delete == null)
            {
                return (int)ProcessStatus.NotFound;
            }
            else
            {
                _userContext.Users.Remove(delete);
                try
                {

                    if (await _userContext.SaveChangesAsync() > 0)
                    {
                        return (int)ProcessStatus.Success;
                    }
                    else
                    {
                        return (int)ProcessStatus.Failed;
                    }
                }
                catch (Exception e)
                {
                    return (int)ProcessStatus.Exception;
                }
            }
        }

        public async Task<User> UpdatePassword(string email, string password)
        {
            
            User user = (from u in _userContext.Users
                       where u.Email == email
                       select u).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Not found");
            }
            else
            {
                user.Password = password;
                if (await _userContext.SaveChangesAsync() > 0)
                {
                    return user;

                }
                else
                {
                    throw new Exception("Register unchanged");
                }
            }

        }
        #endregion


    }
}
