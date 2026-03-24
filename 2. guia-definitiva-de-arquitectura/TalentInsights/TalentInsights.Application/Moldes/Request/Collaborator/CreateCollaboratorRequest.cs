using System.ComponentModel.DataAnnotations;
using TalentInsights.Shared.Constants;

namespace TalentInsights.Application.Moldes.Request.Collaborator
{
    public class CreateCollaboratorRequest
    {
        [Required]
        [MaxLength(150, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(10, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public required string FullName { get; set; }
        public string? Gitlabprofile { get; set; }
        [Required]
        public required string Position { get; set; }

    }
}
