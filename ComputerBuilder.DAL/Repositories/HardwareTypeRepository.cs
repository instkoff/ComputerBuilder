using ComputerBuilder.DAL.Entities;

namespace ComputerBuilder.DAL.Repositories
{
    public class HardwareTypeRepository : Repository<HardwareTypeEntity>, IHardwareTypeRepository
    {
        private DataContext DataContext
        {
            get { return _context as DataContext; }
        }
        public HardwareTypeRepository(DataContext context) : base(context)
        {

        }
    }
}
