using BAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    
    public class LoginController : ApiController
    {
        UserBAL userBAL = new UserBAL();
       
        [HttpPost]
        public HttpResponseMessage RegisterUser(User user)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (userBAL.SaveUser(user))
            {
                response.StatusCode = HttpStatusCode.Created;
            }
            else
            {
                response.StatusCode = HttpStatusCode.Forbidden;
            }
            return response;
        }

        [HttpPost]
        public HttpResponseMessage LoginUser(LoginUser loginUser)
        {
            HttpResponseMessage response= new HttpResponseMessage();
            string Token = userBAL.LoginUser(loginUser);
            if (!string.IsNullOrEmpty(Token))
            {
                response.StatusCode  = HttpStatusCode.OK;
                response.Headers.Add("Token", Token);
            }
            else
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
            }
            return response;
        }

    }
}
