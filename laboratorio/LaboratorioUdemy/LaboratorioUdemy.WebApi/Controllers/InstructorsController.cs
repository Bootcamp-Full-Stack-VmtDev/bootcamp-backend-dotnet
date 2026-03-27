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
            var response = instructorService.Create(model);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = instructorService.Get(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllInstructorRequest model)
        {
            var response = instructorService.Get(model.Limit ?? 0, model.Offset ?? 0);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = instructorService.Delete(id);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest model, Guid id)
        {
            var response = instructorService.Update(id, model);
            return Ok(response);
        }
    }
}
