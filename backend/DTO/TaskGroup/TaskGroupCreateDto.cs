using System.ComponentModel.DataAnnotations;

namespace backend.DTO
{
    public class CreateTaskGroupDto
    {
        [Required]
        public string GroupName {get;set;} = string.Empty;
        public string GroupColor {get;set;} = string.Empty;
    }
}