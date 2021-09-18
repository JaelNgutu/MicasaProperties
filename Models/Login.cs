﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Models
{
    public class Login
    {

        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length 4")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }


    }
}
