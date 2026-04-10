using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace backend.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        public string Email {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public string GoogleAuthId{get;set;} = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}