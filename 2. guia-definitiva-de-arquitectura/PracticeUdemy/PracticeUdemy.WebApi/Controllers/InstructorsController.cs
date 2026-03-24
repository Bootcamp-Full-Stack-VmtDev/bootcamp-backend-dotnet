using Microsoft.AspNetCore.Mvc;
using PracticeUdemy.Application.Models.Request.Instructor;

namespace PracticeUdemy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateInstructorRequest model)
        {
            return Ok($"Instructor {model.name} creado");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Todos los instructores");
        }

        [HttpPut]
        public async Task<IActionResult> update()
        {
            return Ok("Instructor creado");
        }

        [HttpDelete]
        public async Task<IActionResult> delete()
        {
            return Ok("Instructor eliminado");
        }
    }
}
