using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataManager.Data
{
    public class RetailUser : IdentityUser
    {
        // Todo: Add more constraints on the full name field
        [PersonalData]
        [MaxLength(80)]
        [Required]
        public string FullName { get; set; }
    }
}
