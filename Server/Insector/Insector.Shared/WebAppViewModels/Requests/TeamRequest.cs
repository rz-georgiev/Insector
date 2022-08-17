using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public class TeamRequest : BaseRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public ICollection<int> ProjectsIds { get; set; }

        public ICollection<int> UsersIds { get; set; }
    }
}