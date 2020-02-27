using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<HardwareItemEntity>> GetFullHwItemsAsync()
        {
            return await DataContext.HardwareItems.Include(m => m.Manufacturer).Include(h => h.HardwareType).Include(p => p.PropertyList).ToListAsync();
        }
    }
}
