namespace Insector.Shared.WebAppViewModels.Requests
{
    public class UserRegisterRequest
    {
        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public virtual IEnumerable<UserRegisterRoleRequest> RolesIds { get; set; }
    }
}