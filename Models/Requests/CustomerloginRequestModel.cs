using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2p_web_api.Models.Requests
{
    public class CustomerloginRequestModel
    {
        public string customerEmail { get; set; }
        public string customerPassword { get; set; }
    }
}