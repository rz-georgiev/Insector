using AutoMapper;
using Insector.Data;
using Insector.Data.Interfaces;
using Insector.Helpers;
using Insector.Shared.WebAppViewModels.Requests;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Insector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = $"{RolesConstants.Administrator}")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        
        [HttpPost("Save")]
        public async Task<IActionResult> SaveAsync(TeamRequest request)
        {
            request.PerformedByUserId = HttpContext.GetUserId();
            var result = await _teamService.SaveAsync(request);

            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _teamService.DeleteAsync(id);
            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }
    }
}