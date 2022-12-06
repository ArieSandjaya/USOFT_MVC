using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USOFT.Models
{
    public class User
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "User Id")]
        public string pivchUserId { get; set; }

        public string pivchUserName { get; set; }
        public string pivchNIK { get; set; }
        public int piintBranchId { get; set; }
        public string pivchEmail { get; set; }
        public string pivchEmailB2B { get; set; }
        public string pivchPass { get; set; }
        public string pivchCanSendEmail { get; set; }
        public string pivchCanChangePass { get; set; }
        public bool isActive { get; set; }
        public string pivchInputID { get; set; }
    }
}