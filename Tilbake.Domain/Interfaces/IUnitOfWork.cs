using System;
using System.Threading.Tasks;

namespace Tilbake.Domain.Interfaces
{
    public interface  IUnitOfWork
    {
        IKlientRepository Klient { get; }
        ITitleRepository Title { get; }

        Task CompleteAsync();
    }
}
