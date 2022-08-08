using Insector.Data.Models;

namespace Insector.Data.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string email, string password, string avatarUrl, string nickname, IEnumerable<Role> roles);

        Task<User> GetByEmailAndPasswordAsync(string username, string password);
    }
}