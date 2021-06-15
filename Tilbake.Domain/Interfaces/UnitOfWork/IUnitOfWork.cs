namespace Tilbake.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}