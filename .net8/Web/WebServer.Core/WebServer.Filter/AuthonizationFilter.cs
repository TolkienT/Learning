using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common.Helpers;

namespace WebServer.Filter
{
    public class AuthonizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            var services = httpContext.RequestServices;
            var request = httpContext.Request;
            var response = httpContext.Response;
            string clientToken = request.Headers["Authorization"].ToString();

            JwtHelper.GetUserInfo(clientToken);

        }
    }
}
