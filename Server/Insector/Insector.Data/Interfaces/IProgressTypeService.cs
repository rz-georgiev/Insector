using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface IProgressTypeService
    {
        Task<bool> SaveAsync(ProgressTypeRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ProgressTypeResponse>> GetAllAsync();
    }
}