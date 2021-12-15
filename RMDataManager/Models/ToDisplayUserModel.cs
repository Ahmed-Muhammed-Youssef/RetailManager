using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMDataManager.Models
{
    public class ToDisplayUserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();
    }
}