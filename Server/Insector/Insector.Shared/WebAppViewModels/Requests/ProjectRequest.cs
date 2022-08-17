using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public class ProjectRequest : BaseRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        public int AssignedToTeamId { get; set; }
    }
}