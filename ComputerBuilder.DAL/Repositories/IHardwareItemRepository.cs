using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IHardwareItemRepository : IRepository<HardwareItemEntity>
    {
        Task<IQueryable<HardwareItemEntity>> GetFullHwItemsAsync();
    }
}