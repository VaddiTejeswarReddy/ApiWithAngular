using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Interface
{
    public interface IUserDetails
    {
        public string GetDetailsOfUser(HttpContext httpContext);
    }
}
