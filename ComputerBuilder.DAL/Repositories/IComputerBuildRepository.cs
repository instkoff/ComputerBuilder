using ComputerBuilder.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IComputerBuildRepository : IRepository<ComputerBuildEntity>
    {
        Task<IEnumerable<ComputerBuildEntity>> GetPcBuilds();
    }
}