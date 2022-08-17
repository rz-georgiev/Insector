using System.Text.Json.Serialization;

namespace Insector.Shared.WebAppViewModels.Responses
{
    public abstract class BaseResponseModel
    {
        public string ErrorMessage { get; set; }
    }
}