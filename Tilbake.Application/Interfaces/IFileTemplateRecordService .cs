using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IFileTemplateRecordService
    {
        Task<IEnumerable<FileTemplateRecordResource>> GetAllAsync();
        Task<IEnumerable<FileTemplateRecordResource>> GetByFileTemplateIdAsync(Guid fileTemplateId);
        Task<IEnumerable<FileTemplateRecordResource>> GetTableFileTemplate(Guid fileTemplateId, string tableName);
        Task<FileTemplateRecordResource> GetByIdAsync(Guid id);
        Task<int> UpdateAsync(FileTemplateRecordResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(FileTemplateRecordResource resource);
    }
}
