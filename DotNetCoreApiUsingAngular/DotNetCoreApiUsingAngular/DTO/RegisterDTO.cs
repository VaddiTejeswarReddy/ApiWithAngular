using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApiUsingAngular.DTO
{
    public class RegisterDTO
    {
        [Required (ErrorMessage = "UserName can not be Empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can not be Empty")]
        public string Password { get; set; }
    }
}
