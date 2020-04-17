using MySql.Data.MySqlClient;
using p2p_web_api.Models.Requests;
using p2p_web_api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2p_web_api.Utils;

namespace p2p_web_api.Connector
{
    public class CustomerRepository
    {
        private string connectstring;
        public CustomerRepository()
        {
            connectstring = @"server=p2pmaindb.crjqjvqsqaox.ca-central-1.rds.amazonaws.com;username=admin;password=m3Dicine2020!;database=p2pmedicaldb";
        }

        public LoginResponseDetailsModel loginRequest(CustomerloginRequestModel customerloginRequestModel)
        {
            LoginResponseDetailsModel loginResponseDetailsModel = new LoginResponseDetailsModel();
            List<CustomerLoginRequestResponse> loginRequestResponses = new List<CustomerLoginRequestResponse>();
            using (MySqlConnection sqlConnection = new MySqlConnection(connectstring))
            {
                using (MySqlCommand mySqlCommand = sqlConnection.CreateCommand())
                {
                    try
                    {
  

                    }
                    catch (Exception e)
                    {
                        loginResponseDetailsModel.Message = e.ToString();
                    }
                    
                }
            }
            if (loginRequestResponses.Count <= 0)
            {
                loginResponseDetailsModel.loginRequestResponses = loginRequestResponses;
                loginResponseDetailsModel.Message = "Nodata Found";
                loginResponseDetailsModel.responseCode = "200";
                Console.WriteLine(" SIZE ", loginRequestResponses.Count);
            }
            else
            {
                loginResponseDetailsModel.loginRequestResponses = loginRequestResponses;
                loginResponseDetailsModel.Message = "Customer Details";
                loginResponseDetailsModel.responseCode = "200";
                Console.WriteLine(" SIZE ", loginRequestResponses.Count);
            }

            return loginResponseDetailsModel;
        }
    }
}