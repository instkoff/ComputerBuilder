using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IHardwareItemRepository : IRepository<HardwareItemEntity>
    {
        Task<IEnumerable<HardwareItemEntity>> GetFullHwItemsAsync();
    }
}