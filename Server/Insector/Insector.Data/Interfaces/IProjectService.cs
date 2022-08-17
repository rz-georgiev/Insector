using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface IProjectService
    {
        Task<bool> SaveAsync(ProjectRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ProjectResponse>> GetAllAsync();
    }
}