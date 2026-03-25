using Microsoft.AspNetCore.Mvc;
using TalentInsights.Application.Interfaces.Services;
using TalentInsights.Application.Models.Request.Collaborator;

namespace TalentInsights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController(ICollaboratorService collaboratorService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCollaboratorRequest model)
        {
            var rsp = collaboratorService.Create(model);
            return Ok(rsp);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //var context = HttpContext;

            /*if (false)
            {
                HttpContext.Response.StatusCode = 200;
                HttpContext.Request.Headers.Authorization;
                return BadRequest();
            }*/

            /*var respuesta = new GenericResponse<int>
            {
                Message = "Usuario obtenido",
                Data = 1
            };*/

            //var metodo = respuesta.OtroGeneric<string>
            var usuarioId = id;
            return Ok(collaboratorService.Get(usuarioId));
            //return Ok("Ok");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllColaboratorRequest model)
        {
            //List<string> users = ["Usuario 1", "Usuario 2"];
            //return Ok(collaboratorService.Get(users));
            return Ok($"Todos los usuarios: limit: {model.Limit}, offset: {model.Offset}, gitlabProfile: {model.GitlabProfile}");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateCollaboratorRequest model, Guid id)
        {
            return Ok($"Usuario {model.FullName} con id: {id} actualizado!");
        }

        [HttpPatch("change-password/{id:guid}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordCollaboratorRequest model)
        {
            return Ok($"Usuario con id: {id} ha cambiado su contraseña de {model.CurrentPassword} a {model.NewPassword}");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok($"Usuario con id: {id} eliminado!");
        }
    }
}
