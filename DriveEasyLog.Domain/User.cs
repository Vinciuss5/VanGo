using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DriveEasyLog.Domain
{
    public class User : IdentityUser<Guid>
    {
        public string NomeCompleto { get; set; } = string.Empty;
    }
}