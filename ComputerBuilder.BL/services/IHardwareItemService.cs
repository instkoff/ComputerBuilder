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
        Task<IEnumerable<HardwareItemModel>> GetFilteredItems(FilterModel filter);
        Task<HardwareItemModel> GetHwItemByIdAsync(int id);
        Task<int> RemoveHwItem(int id);
        Task<HardwareItemModel> UpdateHwItemAsync(int id, HardwareItemModel itemModel);
    }
}