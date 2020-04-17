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

                        mySqlCommand.CommandText = "SELECT fld_id as fld_id," +
                       "AES_DECRYPT(fld_firstname,'P@PDoctor')as fld_firstname," +
                       "AES_DECRYPT(fld_lastname,'P@PDoctor')as fld_lastname,  " +
                       "AES_DECRYPT(fld_phonenumber,'P@PDoctor')as fld_phonenumber," +
                       "AES_DECRYPT(fld_firstname,'P@PDoctor')as fld_firstname,  " +
                       "AES_DECRYPT(fld_email,'P@PDoctor')as fld_email,  " +
                       "AES_DECRYPT(fld_address1,'P@PDoctor')as fld_address1,  " +
                       "AES_DECRYPT(fld_address2,'P@PDoctor')as fld_address2,  " +
                       "AES_DECRYPT(fld_suitenum,'P@PDoctor')as fld_suitenum,  " +
                       "AES_DECRYPT(fld_city,'P@PDoctor')as fld_city,  " +
                       "AES_DECRYPT(fld_country,'P@PDoctor')as fld_country,  " +
                       "AES_DECRYPT(fld_state,'P@PDoctor')as fld_state,  " +
                       "AES_DECRYPT(fld_postalcode,'P@PDoctor')as fld_postalcode,  " +
                       "AES_DECRYPT(fld_password,'P@PDoctor')as fld_password,  " +
                       "AES_DECRYPT(fld_status,'P@PDoctor')as fld_status,  " +
                       "AES_DECRYPT(fld_datetime,'P@PDoctor')as fld_datetime,  " +
                       "AES_DECRYPT(fld_profile,'P@PDoctor')as fld_profile,  " +
                       "AES_DECRYPT(fld_dob,'P@PDoctor')as fld_dob,  " +
                       "AES_DECRYPT(fld_timezone,'P@PDoctor')as fld_timezone,  " +
                       "AES_DECRYPT(fld_phn_number,'P@PDoctor')as fld_phn_number,  " +
                       "AES_DECRYPT(fld_gender,'P@PDoctor')as fld_gender FROM tbl_customer WHERE fld_email=" + "AES_ENCRYPT('" + customerloginRequestModel.customerEmail.Trim() + "'" + "," + "'" + "P@PDoctor" + "'" + ")" + " AND fld_password=" + "AES_ENCRYPT('" + customerloginRequestModel.customerPassword.Trim() + "'" + "," + "'" + "P@PDoctor" + "'" + ")" + "";

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