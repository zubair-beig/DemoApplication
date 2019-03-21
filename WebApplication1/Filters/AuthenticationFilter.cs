using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication1.Filters
{
    public class AuthenticationFilter : AuthorizationFilterAttribute
    {
        /// <summary>
        /// read requested header and validated
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var identity = FetchFromHeader(actionContext);

            if (identity != null)
            {
               if( !new UserBAL().IsTokenValid(identity))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
        
            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// retrive header detail from the request 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        private string FetchFromHeader(HttpActionContext actionContext)
        {
            string requestToken = null;

            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
                requestToken = authRequest.Parameter;

            return requestToken;
        }
    }
}