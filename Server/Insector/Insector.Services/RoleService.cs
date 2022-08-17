using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace Insector.Services
{
    public class RoleService : IRoleService
    {
        private readonly InsectorDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(InsectorDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(RoleRequest request)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (role == null)
            {
                role = _mapper.Map<Role>(request);
                role.CreatedByUserId = request.PerformedByUserId;

                _context.Add(role);            
            }
            else
            {
                role = _mapper.Map<Role>(request);
                role.LastUpdatedByUserId = request.PerformedByUserId;
                role.LastUpdatedOn = DateTime.UtcNow;

                _context.Update(role);  
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
            var type = await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<IEnumerable<RoleResponse>> GetAllAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            var models = _mapper.Map<IEnumerable<RoleResponse>>(roles);
            return models;
        }
    }
}