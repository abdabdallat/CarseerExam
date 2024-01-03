using Core.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarseerExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : Controller
    {
        private readonly IModelsService _modelsService;

        public ModelsController(IModelsService modelsService)
        {
            _modelsService = modelsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetModels([FromQuery] GetModelRequestDTO request)
        {

            return Ok(await _modelsService.GetModelsForMakeIdYear(request));
        }
    }
}
