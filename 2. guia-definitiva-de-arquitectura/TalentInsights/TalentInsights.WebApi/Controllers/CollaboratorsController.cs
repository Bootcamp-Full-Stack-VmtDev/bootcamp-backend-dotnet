using Microsoft.AspNetCore.Mvc;
using TalentInsights.Application.Moldes.Request.Collaborator;

namespace TalentInsights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCollaboratorRequest model)
        {
            return Ok($"Usuario: {model.FullName} creado!");
        }

        /*
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok($"{id}");
        }*/

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllColaboratorRequest model)
        {
            return Ok($"Todos los usuarios: limit: {model.Limit}, offset: {model.Offset}, gitlabProfile: {model.GitlabProfile}");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateCollaboratorRequest model, Guid id)
        {
            return Ok($"Usuario actualizado: {id} - {model.FullName}");
        }

        [HttpPatch("change-password/{id:guid}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordCollaboratorRequest model)
        {
            return Ok($"Usuario con contraseña cambiada: {model.CurrentPassword} - {model.NewPassword}");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok("Usuario eliminado: {id}");
        }
    }
}
