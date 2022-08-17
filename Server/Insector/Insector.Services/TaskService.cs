using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace Insector.Services
{
    public class TaskService : ITaskService
    {
        private readonly InsectorDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(InsectorDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(TaskRequest request)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (task == null)
            {
                task = _mapper.Map<Data.Models.Task>(request);
                task.CreatedByUserId = request.PerformedByUserId;

                _context.Add(task);            
            }
            else
            {
                task = _mapper.Map<Data.Models.Task>(request);
                task.LastUpdatedByUserId = request.PerformedByUserId;
                task.LastUpdatedOn = DateTime.UtcNow;

                _context.Update(task);  
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
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return false;
            }
            _context.Remove(task);

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

        public async Task<IEnumerable<TaskResponse>> GetAllAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            var models = _mapper.Map<IEnumerable<TaskResponse>>(tasks);
            return models;
        }
    }
}