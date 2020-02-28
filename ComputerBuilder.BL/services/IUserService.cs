using ComputerBuilder.BL.Model.Authorization;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public interface IUserService
    {
        Task<UserModel> GetUser(LoginModel model);
        Task<int> AddUser(LoginModel model);
    }
}
