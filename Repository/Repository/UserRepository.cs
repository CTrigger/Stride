using Model;
using Model.Enum;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<User> GetById(int id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task<int> Insert(User user)
        {
            try
            {
                await _userContext.Users.AddAsync(user);
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

        public async Task<int> Update(User user)
        {
            User update = await _userContext.Users.FindAsync(user.Id);
            if (update == null)
            {
                return (int)ProcessStatus.NotFound;
            }
            else
            {
                update.Email = user.Email;
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

        public async Task<int> Delete(int id)
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


        #endregion


    }
}
