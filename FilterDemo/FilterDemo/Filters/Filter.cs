//using FilterDemo.Data;
//using FilterDemo.Modules;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace FilterDemo.Filters
//{
//    public class Filter : IActionFilter
//    {
//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            throw new NotImplementedException();
//        }

//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            // throw new NotImplementedException();
//            try
//            {
//                var name = GetDetailsBeforeExicution(context.HttpContext);
//                //  var username = GetUserIdentity2FromHeader(context.HttpContext);
//            }
//            catch
//            {
//                Console.WriteLine("Hello");
//            }
//        }

//        public static string GetDetailsBeforeExicution(HttpContext httpContext)
//        {
//            return Convert.ToString(httpContext.Request.Headers["Email"]);
//        }
//        ////public static string GetUserIdentity2FromHeader(HttpContext context)
//        ////{
//        ////    return Convert.ToString(context.Request.Headers["Email"]);
//        ////}
//        //public void OnActionExecuting(ActionExecutingContext context)
//        //{
//        //    try
//        //    {
//        //        var username = GetUserIdentity2FromHeader(context.HttpContext);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return;
//        //    }
//        //}
//        //public void OnActionExecuted(ActionExecutedContext context)
//        //{
//        //    // do something after the action executes
//        //}
//        //public static string GetUserIdentity2FromHeader(HttpContext context)
//        //{
//        //    return Convert.ToString(context.Request.Headers["Email"]);
//        //}
//    }
//}  //

// 
using FilterDemo.Data;
using FilterDemo.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class Filter : IAuthorizationFilter,IResourceFilter,IActionFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var name = Testing(context.HttpContext);
            Console.WriteLine("This is AuthorizationFilter");
        }

        //private static string Testing(HttpContext httpContext)
        //{
        //    Console.WriteLine("Hello");
        //}

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("This is ResourceFilter before Executing....");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("This is ResourceFilter after Executing....");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("This is ActionFilter before Executing....");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("This is ActionFilter after Executing....");
        }
    }
}

