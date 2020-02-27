using ComputerBuilder.BL.Model;
using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public interface IHardwareItemService
    {
        Task<IEnumerable<HardwareItemModel>> GetAllHwItemsFull();
        Task<int> AddHwItem(HardwareItemModel itemModel);
    }
}