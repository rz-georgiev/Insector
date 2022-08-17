using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace Insector.Services
{
    public class ProjectService : IProjectService
    {
        private readonly InsectorDbContext _context;
        private readonly IMapper _mapper;

        public ProjectService(InsectorDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(ProjectRequest request)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (project == null)
            {
                project = _mapper.Map<Project>(request);
                project.CreatedByUserId = request.PerformedByUserId;

                _context.Add(project);            
            }
            else
            {
                project = _mapper.Map<Project>(request);
                project.LastUpdatedByUserId = request.PerformedByUserId;
                project.LastUpdatedOn = DateTime.UtcNow;

                _context.Update(project);  
            }
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var type = await _context.ProgressTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (type == null)
            {
                return false;
            }
            _context.Remove(type);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProjectResponse>> GetAllAsync()
        {
            var types = await _context.Projects.ToListAsync();
            var models = _mapper.Map<IEnumerable<ProjectResponse>>(types);
            return models;
        }
    }
}