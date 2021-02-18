using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBRepository
{
    public interface IUserAccountInterface<T1>
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserByName();
        Task<string> AddUser(T1 entity);
        Task<string> UpdateUser(T1 entity);
        Task<string> DeleteUser(T1 entity);
    }
}
