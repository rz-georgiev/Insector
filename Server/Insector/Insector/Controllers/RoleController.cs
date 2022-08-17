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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        
        [HttpPost("Save")]
        public async Task<IActionResult> SaveAsync(RoleRequest request)
        {
            request.PerformedByUserId = HttpContext.GetUserId();
            var result = await _roleService.SaveAsync(request);

            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }
    }
}