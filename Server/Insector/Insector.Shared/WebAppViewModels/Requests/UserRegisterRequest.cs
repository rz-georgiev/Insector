using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public class UserRegisterRequest : BaseRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Password { get; set; }

        public string AvatarUrl { get; set; }

        [Required]
        public IEnumerable<int> RolesIds { get; set; }
    }
}