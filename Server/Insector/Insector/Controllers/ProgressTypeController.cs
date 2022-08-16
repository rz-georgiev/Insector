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
    public class ProgressTypeController : ControllerBase
    {
        private readonly IProgressTypeService _progressTypeService;
        private readonly IMapper _mapper;

        public ProgressTypeController(IProgressTypeService progressTypeService,
            IMapper mapper)
        {
            _progressTypeService = progressTypeService;
            _mapper = mapper;
        }
        
        [HttpPost("Save")]
        public async Task<IActionResult> SaveAsync(ProgressTypeRequest request)
        {
            request.PerformedByUserId = HttpContext.GetUserId();
            var result = await _progressTypeService.SaveAsync(request);       
          
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _progressTypeService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var types = await _progressTypeService.GetAllAsync();
            var models = _mapper.Map<IEnumerable<ProgressTypeResponse>>(types);
            return Ok(models);
        }
    }
}