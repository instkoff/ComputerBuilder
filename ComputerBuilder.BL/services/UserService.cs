using AutoMapper;
using ComputerBuilder.BL.Model.Authorization;
using ComputerBuilder.DAL.Entities;
using ComputerBuilder.DAL.Repositories;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryContainer _repositoryContainer;
        private readonly IMapper _mapper;

        public UserService(IRepositoryContainer repositoryContainer, IMapper mapper)
        {
            _repositoryContainer = repositoryContainer;
            _mapper = mapper;
        }

        public async Task<int> AddUser(LoginModel model)
        {
            var userModel = new UserModel { Username = model.Username, PasswordHash = model.Password };
            await _repositoryContainer.Users.AddAsync(_mapper.Map<UserEntity>(userModel));
            return await _repositoryContainer.CommitAsync();
        }

        public async Task<UserModel> GetUser(LoginModel model)
        {
            var userEntity = await _repositoryContainer.Users.SingleOrDefaultAsync(u => u.Username == model.Username && u.PasswordHash == model.Password);
            return _mapper.Map<UserModel>(userEntity);
        }
    }
}
