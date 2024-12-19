using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicXAutomationSystem.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class CurrentUserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public int? ReferenceToId { get; set; }
        //public int ReferenceToId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}