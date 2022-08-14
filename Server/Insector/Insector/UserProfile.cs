using AutoMapper;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ProgressType, ProgressTypeResponse>();
        }
    }
}
