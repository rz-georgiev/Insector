using Insector.Shared.WebAppViewModels.Requests;
using System.ComponentModel.DataAnnotations;

namespace Insector.Shared.WebAppViewModels.Responses
{
    public class RoleRequest : BaseRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}