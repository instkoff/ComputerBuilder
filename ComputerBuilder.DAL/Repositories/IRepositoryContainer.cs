using System;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IRepositoryContainer : IDisposable
    {
        HardwareItemRepository HwItems { get; }
        Task<int> CommitAsync();
    }
}