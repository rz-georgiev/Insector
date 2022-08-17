using AutoMapper;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;

namespace Insector
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Role, RoleResponse>();
            
            CreateMap<ProgressType, ProgressTypeResponse>();
            CreateMap<ProgressTypeRequest, ProgressType>();
            
            CreateMap<Project, ProjectResponse>();
            CreateMap<ProjectRequest, Project>();
        }
    }
}
