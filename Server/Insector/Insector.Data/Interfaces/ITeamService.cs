using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface ITeamService
    {
        Task<bool> SaveAsync(TeamRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<TeamResponse>> GetAllAsync();
    }
}