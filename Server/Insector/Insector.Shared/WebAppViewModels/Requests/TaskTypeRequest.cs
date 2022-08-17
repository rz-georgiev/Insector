using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public class TaskTypeRequest : BaseRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}