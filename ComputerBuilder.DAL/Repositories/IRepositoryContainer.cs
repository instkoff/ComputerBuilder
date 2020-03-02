using System;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IRepositoryContainer : IDisposable
    {
        HardwareItemRepository HwItems { get; }
        UserRepository Users { get; }
        ComputerBuildRepository ComputerBuilds { get; }
        ManufacturerRepository Manufacturers { get; }
        HardwareTypeRepository HardwareTypes { get; }
        Task<int> CommitAsync();

    }
}