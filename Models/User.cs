using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Models
{
    public class User
    {

        public string UserName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),Required,MinLength(4, ErrorMessage ="Minimum length 4")]
        public string Password { get; set; }

        public User() { }

        public User(AppUser appuser)
        {
            UserName = appuser.Email;
            Email = appuser.Email;
            Password = appuser.PasswordHash;
        }

    }
}
