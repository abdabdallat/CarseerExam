using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarseerExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : Controller
    {

        public ModelsController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetModels([FromQuery] int modelYear, [FromQuery] string make)
        {


            return Ok();
        }
    }
}
