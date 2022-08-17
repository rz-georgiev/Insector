using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace Insector.Services
{
    public class TaskTypeService : ITaskTypeService
    {
        private readonly InsectorDbContext _context;
        private readonly IMapper _mapper;

        public TaskTypeService(InsectorDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(TaskTypeRequest request)
        {
            var taskType = await _context.TaskTypes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (taskType == null)
            {
                taskType = _mapper.Map<TaskType>(request);
                taskType.CreatedByUserId = request.PerformedByUserId;

                _context.Add(taskType);            
            }
            else
            {
                taskType = _mapper.Map<TaskType>(request);
                taskType.LastUpdatedByUserId = request.PerformedByUserId;
                taskType.LastUpdatedOn = DateTime.UtcNow;

                _context.Update(taskType);  
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
            var taskType = await _context.TaskTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (taskType == null)
            {
                return false;
            }
            _context.Remove(taskType);

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

        public async Task<IEnumerable<TaskTypeResponse>> GetAllAsync()
        {
            var taskTypes = await _context.TaskTypes.ToListAsync();
            var models = _mapper.Map<IEnumerable<TaskTypeResponse>>(taskTypes);
            return models;
        }
    }
}