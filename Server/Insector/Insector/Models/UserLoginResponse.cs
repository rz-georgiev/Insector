using Insector.Data.Models;

namespace Insector.Models
{
    public class UserLoginResponse
    {
        public string Email { get; set; }

        public string Nickname { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
