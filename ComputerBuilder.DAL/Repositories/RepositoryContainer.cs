using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private readonly DataContext _dataContext;
        private HardwareItemRepository _hardwareItemRepository;
        private UserRepository _userRepository;

        public RepositoryContainer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public HardwareItemRepository HwItems => _hardwareItemRepository = _hardwareItemRepository ?? new HardwareItemRepository(_dataContext);
        public UserRepository Users => _userRepository = _userRepository ?? new UserRepository(_dataContext);

        public async Task<int> CommitAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
