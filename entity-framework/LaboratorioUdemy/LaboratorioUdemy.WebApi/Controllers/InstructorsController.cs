using LaboratorioUdemy.Application.Interfaces.Services;
using LaboratorioUdemy.Application.Models.Requests.Instructor;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioUdemy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController(IInstructorService instructorService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInstructorRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await instructorService.Create(model);

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Data!.InstructorId },
                response
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await instructorService.Get(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterInstructorRequest model)
        {
            var response = instructorService.Get(model);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await instructorService.Delete(id);

            if (!response.Data)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest model, Guid id)
        {
            var response = await instructorService.Update(id, model);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
