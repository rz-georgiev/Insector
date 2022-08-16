using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Insector.Shared.WebAppViewModels.Requests
{
    public abstract class BaseRequestModel
    {
        [JsonIgnore]
        public int PerformedByUserId { get; set; }
    }
}