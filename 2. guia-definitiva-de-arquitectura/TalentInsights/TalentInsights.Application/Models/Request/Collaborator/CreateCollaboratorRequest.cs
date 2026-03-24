using System.ComponentModel.DataAnnotations;
using TalentInsights.Shared.Constants;

namespace TalentInsights.Application.Models.Request.Collaborator
{
    public class CreateCollaboratorRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(150, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(10, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string FullName { get; set; } = null!;

        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(15, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string? Gitlabprofile { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(100, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(5, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string Position { get; set; } = null!;

    }
}
