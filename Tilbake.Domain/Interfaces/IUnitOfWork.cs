using System.Threading.Tasks;

namespace Tilbake.Domain.Interfaces
{
    public interface  IUnitOfWork
    {
        Task CompleteAsync();
    }
}
