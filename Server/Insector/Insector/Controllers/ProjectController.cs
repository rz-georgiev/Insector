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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpPost("Save")]
        public async Task<IActionResult> SaveAsync(ProjectRequest request)
        {
            request.PerformedByUserId = HttpContext.GetUserId();
            var result = await _projectService.SaveAsync(request);

            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }
    }
}