using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using p2p_web_api.Models.Responses;
using p2p_web_api.Models.Requests;
using p2p_web_api.Connector;

namespace p2p_web_api.Controllers
{
    public class CustomerController : ApiController
    {
      [HttpPost]
      public LoginResponseDetailsModel loginResponseDetailsModel(CustomerloginRequestModel customerloginRequest)
        {
            LoginResponseDetailsModel loginResponseDetailsModel = new LoginResponseDetailsModel();
            CustomerRepository repository = new CustomerRepository();
            loginResponseDetailsModel = repository.loginRequest(customerloginRequest);
            return loginResponseDetailsModel;
        }
    }
}
