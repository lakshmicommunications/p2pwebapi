using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2p_web_api.Models.Responses
{
    public class LoginResponseDetailsModel
    {
        public string responseCode { get; set; }
        public string Message { get; set; }
        public List<CustomerLoginRequestResponse> loginRequestResponses { get; set; }
    }
}