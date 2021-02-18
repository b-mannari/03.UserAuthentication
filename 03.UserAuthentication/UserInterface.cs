using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationService.ClassObjects;

namespace UserAuthenticationService
{
    public interface IUserInterface
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserByName(string Username);
        Task<bool> AddUser(UserModel model);
        Task<bool> Login(UserModel model);
        //Task<string> UpdateUser(UserModel model);
        //Task<string> DeleteUser(UserModel model);
    }
}
