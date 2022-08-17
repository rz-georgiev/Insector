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
    public class TaskTypeController : ControllerBase
    {
        private readonly ITaskTypeService _taskTypeService;

        public TaskTypeController(ITaskTypeService taskTypeService)
        {
            _taskTypeService = taskTypeService;
        }
        
        [HttpPost("Save")]
        public async Task<IActionResult> SaveAsync(TaskTypeRequest request)
        {
            request.PerformedByUserId = HttpContext.GetUserId();
            var result = await _taskTypeService.SaveAsync(request);

            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _taskTypeService.DeleteAsync(id);
            return result ? Ok("Successful operation") : BadRequest("Unsuccessful operation");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var taskTypes = await _taskTypeService.GetAllAsync();
            return Ok(taskTypes);
        }
    }
}