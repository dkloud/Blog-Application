using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Account
{
    public class RegisterModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Your login must be between 4 and 30 characters")]
        [Remote(action: "CheckLogin", controller: "Account", ErrorMessage = "Login is already in use")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Your password must be between 4 and 30 characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please make sure your passwords match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }       

        
        //public IFormFile Image { get; set; }
    }
}
