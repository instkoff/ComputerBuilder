using ComputerBuilder.BL.Model.Authorization;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public interface IUserService
    {
        Task<UserModel> GetUserLogin(LoginModel model);
        Task<int> AddUser(RegisterModel model);
        Task<UserModel> GetUserRegister(RegisterModel model);
    }
}
