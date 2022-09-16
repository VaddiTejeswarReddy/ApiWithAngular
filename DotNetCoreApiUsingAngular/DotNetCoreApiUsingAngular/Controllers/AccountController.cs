using DotNetCoreApiUsingAngular.BaseApiController;
using DotNetCoreApiUsingAngular.Data;
using DotNetCoreApiUsingAngular.DTO;
using DotNetCoreApiUsingAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreApiUsingAngular.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly DataContext _dataContext;
        public AccountController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            if (UserCheck(registerDTO.UserName))
            {
                return BadRequest("User already Exists.!");
            }

            using var hmac = new HMACSHA512();
            AppUser user = new AppUser() {
                UserName = registerDTO.UserName.ToLower()
            , PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password.ToLower()))
            , PasswordSalt = hmac.Key
            };
            this._dataContext.Users.Add(user);
            this._dataContext.SaveChanges();
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult UserLogin([FromBody] LoginDTO loginDTO)
        {
          var isExists =  this._dataContext.Users.SingleOrDefault(
                option => option.UserName.ToLower() == loginDTO.UserName.ToLower()
                );
            if (isExists == null) return Unauthorized("UserName not found");
            using var hmac = new HMACSHA512(isExists.PasswordSalt);
            var decoading = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.UserName));
            for (int i = 0; i < decoading.Length; i++)
            {
                if (decoading[i] != isExists.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return Ok(isExists);
        }

        private bool UserCheck(string userName)
        {
            var Exists = this._dataContext.Users.Any(options => options.UserName == userName.ToLower());
            return Exists;
        }
    }
}
