using FilterDemo.Data;
using FilterDemo.Filters;
using FilterDemo.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserDetails>> Get()
        {
            var details = this._dataContext.Student.ToList();
            return details;
        }
    }
}
