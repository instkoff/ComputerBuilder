using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public class HardwareItemRepository : Repository<HardwareItemEntity>, IHardwareItemRepository
    {
        private DataContext DataContext
        {
            get { return _context as DataContext; }
        }
        public HardwareItemRepository(DataContext context) : base(context)
        {
        }

        public async Task<IQueryable<HardwareItemEntity>> GetFullHwItemsAsync()
        {
            return await Task.Run(()=>DataContext.HardwareItems
                .Include(m => m.Manufacturer)
                .Include(h => h.HardwareType)
                .Include(pi => pi.PropertiesItems)
                .ThenInclude(p=>p.CompatibilityProperty));
        }
    }
}
