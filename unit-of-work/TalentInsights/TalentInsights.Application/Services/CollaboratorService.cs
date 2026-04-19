using Microsoft.Extensions.Configuration;
using TalentInsights.Application.Helpers;
using TalentInsights.Application.Interfaces.Services;
using TalentInsights.Application.Models.DTOs;
using TalentInsights.Application.Models.Requests.Collaborator;
using TalentInsights.Application.Models.Responses;
using TalentInsights.Domain.Database.SqlServer;
using TalentInsights.Domain.Database.SqlServer.Entities;
using TalentInsights.Domain.Exceptions;
using TalentInsights.Shared;
using TalentInsights.Shared.Constants;
using TalentInsights.Shared.Helpers;

namespace TalentInsights.Application.Services
{
    public class CollaboratorService(IUnitOfWork uow, IConfiguration configuration, SMTP smtp) : ICollaboratorService
    {
        public async Task<GenericResponse<CollaboratorDto>> Create(CreateCollaboratorRequest model)
        {
            var password = Generate.RandomText(32);
            var create = await uow.collaboratorRepository.Create(new Collaborator
            {
                GitlabProfile = model.GitlabProfile,
                FullName = model.FullName,
                Position = model.Position,
                Email = model.Email,
                Password = password
            });

            await smtp.Send(model.Email, "Registro de usuario - TalentInsights",
            $"""
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset="UTF-8">
            </head>
            <body style="margin:0; padding:0; background-color:#f4f4f4; font-family:Arial, sans-serif;">
                <table width="100%" cellpadding="0" cellspacing="0" style="padding:20px;">
                    <tr>
                        <td align="center">
                            <table width="600" cellpadding="0" cellspacing="0" style="background-color:#ffffff; border-radius:8px; padding:30px;">
                                <tr>
                                    <td align="center" style="padding-bottom:20px;">
                                        <h2 style="margin:0; color:#333;">TalentInsights</h2>
                                            <p style="margin:0; color:#777;">Bienvenido a la plataforma</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color:#333; font-size:14px; line-height:1.6;">
                                        <p>Hola <strong>{model.FullName}</strong>,</p>
                                        <p>
                                            Tu cuenta ha sido creada exitosamente. A continuación encontrarás tus credenciales de acceso:
                                        </p>
                                        <table width="100%" cellpadding="10" cellspacing="0" style="background-color:#f9f9f9; border-radius:6px; margin:20px 0;">
                                            <tr>
                                                <td>
                                                    <p style="margin:5px 0;"><strong>Email:</strong> {model.Email}</p>
                                                    <p style="margin:5px 0;"><strong>Contraseña:</strong> {password}</p>
                                                    <p style="margin:5px 0;"><strong>Rol:</strong> {model.Position}</p>
                                                </td>
                                            </tr>
                                        </table>
                                        <p>
                                            Te recomendamos cambiar tu contraseña después de iniciar sesión por primera vez.
                                        </p>
                                        
                                        <table cellpadding="0" cellspacing="0" style="margin:20px 0;">
                                            <tr>
                                                <td align="center" bgcolor="#007BFF" style="border-radius:5px;">
                                                    <a href="#" style="display:inline-block; padding:12px 20px; color:#ffffff; text-decoration:none; font-size:14px;">
                                                        Iniciar sesión
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <p style="margin-top:30px;">
                                            Saludos,<br>
                                            Equipo de TalentInsights
                                        </p>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td align="center" style="padding-top:20px; font-size:12px; color:#999;">
                                        © {DateTime.UtcNow.Year} TalentInsights. Todos los derechos reservados.
                                    </td>
                                </tr>
                                
                            </table>
                            
                        </td>
                    </tr>
                </table>

            </body>
            </html>
            """);

            await uow.SaveChangesAsync();

            return ResponseHelper.Create(Map(create));
        }

        public async Task<GenericResponse<bool>> Delete(Guid collaboratorId)
        {
            var collaborator = await GetCollaborator(collaboratorId);

            collaborator.DeletedAt = DateTimeHelper.UtcNow();
            await uow.collaboratorRepository.Update(collaborator);

            await uow.SaveChangesAsync();

            return ResponseHelper.Create(true);
        }

        public GenericResponse<List<CollaboratorDto>> Get(FilterColaboratorRequest model)
        {
            var queryable = uow.collaboratorRepository.Queryable();

            // Filtrado de nombre
            if (!string.IsNullOrWhiteSpace(model.FullName))
            {
                queryable = queryable.Where(x => x.FullName.Contains(model.FullName ?? ""));
            }

            // Filtrado de perfil de gitlab
            if (!string.IsNullOrWhiteSpace(model.GitlabProfile))
            {
                queryable = queryable.Where(x => x.GitlabProfile != null && x.GitlabProfile.Contains(model.GitlabProfile ?? ""));
            }

            // Filtrado del cargo
            if (!string.IsNullOrWhiteSpace(model.Position))
            {
                queryable = queryable.Where(x => x.Position.Contains(model.Position ?? ""));
            }

            // Realizar paginación y realizar consulta
            var collaborators = queryable.Skip(model.Offset).Take(model.Limit).ToList();

            // Mapear colaboradores
            List<CollaboratorDto> mapped = [];
            foreach (var collaborator in collaborators)
            {
                mapped.Add(Map(collaborator));
            }

            return ResponseHelper.Create(mapped);
        }

        public async Task<GenericResponse<CollaboratorDto>> Get(Guid collaboratorId)
        {
            var collaborator = await GetCollaborator(collaboratorId);
            return ResponseHelper.Create(Map(collaborator));
        }

        public async Task<GenericResponse<CollaboratorDto>> Update(Guid collaboratorId, UpdateCollaboratorRequest model)
        {
            var collaborator = await GetCollaborator(collaboratorId);

            collaborator.GitlabProfile = model.GitlabProfile ?? collaborator.GitlabProfile;
            collaborator.Position = model.Position ?? collaborator.Position;
            collaborator.FullName = model.FullName ?? collaborator.FullName;
            collaborator.Email = model.Email ?? collaborator.Email;

            collaborator.UpdatedAt = DateTimeHelper.UtcNow();

            var update = await uow.collaboratorRepository.Update(collaborator);

            await uow.SaveChangesAsync();

            return ResponseHelper.Create(Map(update));
        }

        private async Task<Collaborator> GetCollaborator(Guid collaboratorId)
        {
            return await uow.collaboratorRepository.Get(collaboratorId)
                ?? throw new NotFoundException(ResponseConstants.COLLABORATOR_NOT_EXISTS);
        }

        private static CollaboratorDto Map(Collaborator collaborator)
        {
            return new CollaboratorDto
            {
                CollaboratorId = collaborator.Id,
                FullName = collaborator.FullName,
                Position = collaborator.Position,
                GitlabProfile = collaborator.GitlabProfile,
                JoinedAt = collaborator.JoinedAt,
                CreatedAt = collaborator.CreatedAt,
                IsActive = collaborator.IsActive
            };
        }

        public async Task CreateFirstUser()
        {
            var hasCreated = await uow.collaboratorRepository.HasCreated();
            if (hasCreated) return;

            var fullName = configuration[ConfigurationConstants.FIRST_APP_TIME_USER_FULLNAME]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.FIRST_APP_TIME_USER_FULLNAME));

            var email = configuration[ConfigurationConstants.FIRST_APP_TIME_USER_EMAIL]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.FIRST_APP_TIME_USER_EMAIL));

            var position = configuration[ConfigurationConstants.FIRST_APP_TIME_USER_POSITION]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.FIRST_APP_TIME_USER_POSITION));

            var password = configuration[ConfigurationConstants.FIRST_APP_TIME_USER_PASSWORD]
                ?? throw new Exception(ResponseConstants.ConfigurationPropertyNotFound(ConfigurationConstants.FIRST_APP_TIME_USER_PASSWORD));

            var adminRole = await uow.collaboratorRepository.GetRole(RoleConstants.Admin)
                ?? throw new Exception(ResponseConstants.RoleNotFound(RoleConstants.Admin));

            await uow.collaboratorRepository.Create(new Collaborator
            {
                FullName = fullName,
                Email = email,
                Position = position,
                Password = Hasher.HashPassword(password),
                CollaboratorRoleCollaborators = [
                    new CollaboratorRole
                    {
                        RoleId = adminRole.Id,
                    }
                ]
            });

            await uow.SaveChangesAsync();
        }
    }
}
