using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ITRoot.Models;
using Microsoft.AspNetCore.Identity;

namespace ITRoot.Models
{
    public class ApplicationUser: IdentityUser
    {      
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}