using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private readonly DataContext _dataContext;
        private HardwareItemRepository _hardwareItemRepository;
        private UserRepository _userRepository;
        private ComputerBuildRepository _computerBuildRepository;
        private ManufacturerRepository _manufacturerRepository;
        private HardwareTypeRepository _hardwareTypeRepository;
        private CompatibilityPropertyRepository _compatibilityPropertyRepository;

        public RepositoryContainer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public HardwareItemRepository HwItems => _hardwareItemRepository ??= new HardwareItemRepository(_dataContext);
        public UserRepository Users => _userRepository ??= new UserRepository(_dataContext);
        public ComputerBuildRepository ComputerBuilds => _computerBuildRepository ??= new ComputerBuildRepository(_dataContext);
        public ManufacturerRepository Manufacturers => _manufacturerRepository ??= new ManufacturerRepository(_dataContext);
        public HardwareTypeRepository HardwareTypes => _hardwareTypeRepository ??= new HardwareTypeRepository(_dataContext);
        public CompatibilityPropertyRepository CompatibilityPropertyRepository => _compatibilityPropertyRepository ??= new CompatibilityPropertyRepository(_dataContext);

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
