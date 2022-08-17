using Insector.Shared.WebAppViewModels.Requests;
using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public class TaskRequest : BaseRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public float Progress { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int ProgressId { get; set; }

        [Required]
        public int AssignedToUserId { get; set; }

    }
}