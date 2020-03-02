using ComputerBuilder.DAL.Entities;

namespace ComputerBuilder.DAL.Repositories
{
    public class ManufacturerRepository : Repository<ManufacturerEntity>, IManufacturerRepository
    {
        private DataContext DataContext
        {
            get { return _context as DataContext; }
        }
        public ManufacturerRepository(DataContext context) : base(context)
        {

        }
    }
}
