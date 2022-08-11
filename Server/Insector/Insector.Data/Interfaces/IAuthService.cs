using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector.Data.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(UserLoginRequest request);

        Task<bool> RegisterAsync(UserRegisterRequest request);

        Task<IEnumerable<RoleResponse>> GetRolesAsync();
    }
}