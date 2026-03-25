using Microsoft.AspNetCore.Mvc;
using PracticeUdemy.Application.Models.Request.Instructor;

namespace PracticeUdemy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructorRequest model)
        {
            return Ok($"Instructor {model.Name} con email {model.Email} creado!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Todos los instructores");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest model, Guid id)
        {
            return Ok($"Instructor {model.Name} con id: {id} actualizado!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok($"Instructor con {id} eliminado!");
        }
    }
}
