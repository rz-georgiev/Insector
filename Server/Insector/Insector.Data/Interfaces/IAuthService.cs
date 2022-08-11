using Insector.Shared.WebAppViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insector.Data.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(UserLoginRequest request);

        Task<bool> RegisterAsync(UserRegisterRequest request);
    }
}
