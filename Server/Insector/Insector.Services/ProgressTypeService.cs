using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace Insector.Services
{
    public class ProgressTypeService : IProgressTypeService
    {
        private readonly InsectorDbContext _context;
        private readonly IMapper _mapper;

        public ProgressTypeService(InsectorDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(ProgressTypeRequest request)
        {
            var type = await _context.ProgressTypes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (type == null)
            {
                type = _mapper.Map<ProgressType>(request);
                type.CreatedByUserId = request.PerformedByUserId;

                _context.Add(type);            
            }
            else
            {
                type = _mapper.Map<ProgressType>(request);
                type.LastUpdatedByUserId = request.PerformedByUserId;
                type.LastUpdatedOn = DateTime.UtcNow;

                _context.Update(type);  
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

        public async Task<IEnumerable<ProgressTypeResponse>> GetAllAsync()
        {
            var types = await _context.ProgressTypes.ToListAsync();
            var models = _mapper.Map<IEnumerable<ProgressTypeResponse>>(types);
            return models;
        }
    }
}