using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Helpers;

namespace WebApi.Core.Filter
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
