using ComputerBuilder.DAL.Entities;

namespace ComputerBuilder.DAL.Repositories
{
    public class CompatibilityPropertyRepository : Repository<CompatibilityPropertyEntity>, ICompatibilityPropertyRepository
    {
        private DataContext DataContext
        {
            get
            {
                return _context as DataContext;
            }
        }

        public CompatibilityPropertyRepository(DataContext context) : base(context)
        {
                
        }
    }
}
