using AutoMapper;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Task = Insector.Data.Models.Task;

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

            CreateMap<Role, RoleResponse>();
            CreateMap<RoleRequest, Role>();

            CreateMap<Task, TaskResponse>();
            CreateMap<TaskRequest, Task>();

            CreateMap<TaskType, TaskTypeResponse>();
            CreateMap<TaskTypeRequest, TaskType>();

            CreateMap<Team, TeamResponse>();
            CreateMap<TeamRequest, Team>();
        }
    }
}
