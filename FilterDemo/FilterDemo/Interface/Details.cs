using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Interface
{
    public class Details 
    {
        public string GetUserDetails(HttpContext httpContext)
        {
            return "tejeswar.vaddi@infor.com";
        }
    }
}
