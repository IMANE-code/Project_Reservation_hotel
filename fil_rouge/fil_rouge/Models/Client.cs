using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fil_rouge.Models
{
    public class Client: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
    }
}
