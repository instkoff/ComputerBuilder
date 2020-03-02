using ComputerBuilder.BL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.services
{
    public interface IComputerBuildService
    {
        Task<int> BuildPcAsync(ComputerInfoModel model);
        Task<IEnumerable<ComputerBuildModel>> GetAllPcAsync();
    }
}