﻿using DotNetCoreApiUsingAngular.Interfaces;
using DotNetCoreApiUsingAngular.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetCoreApiUsingAngular.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        public TokenService(IConfiguration configuration)
        {
            this._symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));       
        }
        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,appUser.UserName)
            };

            var creads = new SigningCredentials(_symmetricSecurityKey,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims)
                ,Expires = DateTime.Now.AddDays(30)
                ,SigningCredentials = creads
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
