using System.Threading.Tasks;

namespace Tilbake.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBankRepository Bank { get; }

        Task CompleteAsync();
    }
}