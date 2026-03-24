using System.ComponentModel.DataAnnotations;
using TalentInsights.Shared.Constants;

namespace TalentInsights.Application.Moldes.Request.Collaborator
{
    public class ChangePasswordCollaboratorRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
