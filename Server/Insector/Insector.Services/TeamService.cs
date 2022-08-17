using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.EntityFrameworkCore;

namespace Insector.Services
{
    public class TeamService : ITeamService
    {
        private readonly InsectorDbContext _context;
        private readonly IMapper _mapper;

        public TeamService(InsectorDbContext dbContext,
            IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> SaveAsync(TeamRequest request)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (team == null)
            {
                team = _mapper.Map<Team>(request);
                team.CreatedByUserId = request.PerformedByUserId;

                _context.Add(team);
            }
            else
            {
                team = _mapper.Map<Team>(request);
                team.LastUpdatedByUserId = request.PerformedByUserId;
                team.LastUpdatedOn = DateTime.UtcNow;

                _context.Update(team);
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
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return false;
            }
            _context.Remove(team);

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

        public async Task<IEnumerable<TeamResponse>> GetAllAsync()
        {
            var teams = await _context.Teams.ToListAsync();
            var models = _mapper.Map<IEnumerable<TeamResponse>>(teams);
            return models;
        }
    }
}