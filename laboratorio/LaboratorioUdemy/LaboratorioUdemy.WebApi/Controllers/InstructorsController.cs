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
    }
}
