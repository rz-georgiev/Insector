using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface IRoleService
    {
        Task<bool> SaveAsync(RoleRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<RoleResponse>> GetAllAsync();
    }
}