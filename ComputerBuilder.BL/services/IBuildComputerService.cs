using ComputerBuilder.BL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public interface IBuildComputerService
    {
        Task<int> BuildPcAsync(List<int> hardwareItemIds, string name, string description);
        Task<IEnumerable<ComputerBuildModel>> GetAllPcAsync();
    }
}