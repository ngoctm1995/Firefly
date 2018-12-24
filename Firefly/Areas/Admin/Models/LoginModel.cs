﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Firefly.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string PassWord { get; set; }
        public string RememberMe { get; set; }
    }
}