using System;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IRepositoryContainer : IDisposable
    {
        HardwareItemRepository HwItems { get; }
        UserRepository Users { get; }
        Task<int> CommitAsync();
    }
}