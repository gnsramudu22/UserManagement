using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HCL.API
{
    public class LoginRequest
    {
        public string UserId { get; set; }
        public string Password { get; set; }

    }

    public class LoginResponse
    {
        public LoginResponse()
        {

            Token = "";
            responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
    }
}
