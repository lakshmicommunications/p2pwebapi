using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2p_web_api.Models.Responses
{
    public class CustomerLoginRequestResponse
    {
        public string customerID { get; set; }
        public string customer_FirstName { get; set; }
        public string customer_LastName { get; set; }
        public string customer_Phone { get; set; }
        public string customerEmail { get; set; }
        public string customer_Address1 { get; set; }
        public string customer_Address2 { get; set; }
        public string customer_Suitenum { get; set; }
        public string customer_City { get; set; }
        public string customer_Country { get; set; }
        public string customer_State { get; set; }
        public string customer_PostalCode { get; set; }
        public string customer_Password { get; set; }
        public string customer_Status { get; set; }
        public string customer_DateTime{ get; set; }
        public string customer_Profile { get; set; }
        public string customer_DOB { get; set; }
        public string customer_TimeZone { get; set; }
        public string customer_Phnnumber { get; set; }
        public string customer_Gender{ get; set; }
    }
}