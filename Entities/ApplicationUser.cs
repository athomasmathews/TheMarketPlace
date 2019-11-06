using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public partial class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
