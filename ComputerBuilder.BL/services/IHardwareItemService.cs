using ComputerBuilder.BL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public interface IHardwareItemService
    {
        HardwareItemModel Get(int id);
        List<HardwareItemModel> GetAll();
        Task<int> Create(HardwareItemModel itemModel);
    }
}