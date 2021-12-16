using System.ComponentModel.DataAnnotations;

namespace RMDataManager.Models
{
    public class UserRolePairModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}