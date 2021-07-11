using System;
using System.Threading.Tasks;

namespace Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICarrierRepository Carriers { get; }

        Task<int> SaveAsync();
    }
}
