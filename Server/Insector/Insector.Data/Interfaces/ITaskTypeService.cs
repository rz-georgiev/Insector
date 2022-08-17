using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface ITaskTypeService
    {
        Task<bool> SaveAsync(TaskTypeRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<TaskTypeResponse>> GetAllAsync();
    }
}