using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Data.Models;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Insector.Services
{
    public class ProgressTypeService : IProgressTypeService
    {
        private readonly InsectorDbContext _context;

        public ProgressTypeService(InsectorDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<ProgressType>> GetAllAsync()
        {
            var types = await _context.ProgressTypes.ToListAsync();
            return types;
        }
    }
}