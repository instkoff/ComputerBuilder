using System;
using System.Threading.Tasks;

namespace ComputerBuilder.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        HardwareItemRepository HwItems { get; }
        Task<int> CommitAsync();
    }
}