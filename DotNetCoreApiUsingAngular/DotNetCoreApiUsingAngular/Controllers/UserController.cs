using DotNetCoreApiUsingAngular.BaseApiController;
using DotNetCoreApiUsingAngular.Data;
using DotNetCoreApiUsingAngular.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreApiUsingAngular.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        // GET: api/<UserController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            return await this._dataContext.Users.ToListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public  async Task<ActionResult<AppUser>> Get(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
