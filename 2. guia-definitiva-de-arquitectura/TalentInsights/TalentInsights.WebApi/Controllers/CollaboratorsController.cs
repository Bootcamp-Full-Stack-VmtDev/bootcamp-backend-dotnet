using Microsoft.AspNetCore.Mvc;

namespace TalentInsights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok("Usuario creado");
        }

        /*
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok($"{id}");
        }*/

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Todos los usuarios");
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok("Usuario actualizado");
        }

        [HttpPatch("change-password")]
        public async Task<IActionResult> ChangePassword()
        {
            return Ok("Usuario con contraseña cambiada");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok("Usuario eliminado");
        }
    }
}
