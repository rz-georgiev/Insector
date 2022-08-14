using AutoMapper;
using Insector.Data.Interfaces;
using Insector.Shared.WebAppViewModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Insector.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var types = await _progressTypeService.GetAllAsync();
            var models = _mapper.Map<IEnumerable<ProgressTypeResponse>>(types);
            return Ok(models);
        }
    }
}