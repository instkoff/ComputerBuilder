using ComputerBuilder.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public class ComputerBuildRepository : Repository<ComputerBuildEntity>, IComputerBuildRepository
    {
        private DataContext DataContext
        {
            get { return _context as DataContext; }
        }
        public ComputerBuildRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<ComputerBuildEntity>> GetPcBuilds()
        {
            return await DataContext.ComputerBuilds.Include(bi => bi.BuildItems).ThenInclude(c=>c.HardwareItem).ToListAsync();
        }
    }
}
