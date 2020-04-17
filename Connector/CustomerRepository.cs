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
<<<<<<< HEAD
                       "AES_DECRYPT(fld_gender,'P@PDoctor')as fld_gender FROM tbl_customer WHERE fld_email='"+customerloginRequestModel.customerEmail.Trim()+ "'" + " AND fld_password='"+customerloginRequestModel.customerPassword.Trim()+"'";
                        mySqlCommand.CommandText = "SELECT *FROM tbl_customer WHERE fld_email= '" +/*DataSecurity.Encrypt*/(customerloginRequestModel.customerEmail.Trim()) + "'" + "AND fld_password='" +/*DataSecurity.Encrypt*/(customerloginRequestModel.customerPassword.Trim()) + "'";
=======
                       "AES_DECRYPT(fld_gender,'P@PDoctor')as fld_gender FROM tbl_customer WHERE fld_email="+"AES_ENCRYPT('"+ customerloginRequestModel.customerEmail.Trim()+"'"+","+"'"+ "P@PDoctor"+"'"+")"+ " AND fld_password=" + "AES_ENCRYPT('"+ customerloginRequestModel.customerPassword.Trim() + "'" + "," + "'" + "P@PDoctor" + "'" + ")" + "";

                     
>>>>>>> 3cebcd513dda701af51af69ab1b953061cdd7ddf
                        mySqlCommand.CommandType = System.Data.CommandType.Text;
                        mySqlCommand.Connection = sqlConnection;
                        sqlConnection.Open();
                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                loginRequestResponses.Add(new CustomerLoginRequestResponse
                                {

                                    customerID = (reader.GetString(reader.GetOrdinal("fld_id"))),
                                    customer_FirstName = (reader.GetString(reader.GetOrdinal("fld_firstname"))),
                                    customer_LastName = (reader.GetString(reader.GetOrdinal("fld_lastname"))),
                                    customer_Phone = (reader.GetString(reader.GetOrdinal("fld_phonenumber"))),
                                    customerEmail = (reader.GetString(reader.GetOrdinal("fld_email"))),
                                    customer_Address1 = (reader.GetString(reader.GetOrdinal("fld_address1"))),
                                    customer_Address2 = (reader.GetString(reader.GetOrdinal("fld_address2"))),
                                    customer_Suitenum = (reader.GetString(reader.GetOrdinal("fld_suitenum"))),
                                    customer_City = (reader.GetString(reader.GetOrdinal("fld_city"))),
                                    customer_Country = (reader.GetString(reader.GetOrdinal("fld_country"))),
                                    customer_State = (reader.GetString(reader.GetOrdinal("fld_state"))),
                                    customer_PostalCode = (reader.GetString(reader.GetOrdinal("fld_postalcode"))),
                                    customer_Password = (reader.GetString(reader.GetOrdinal("fld_password"))),
                                    customer_Status = (reader.GetString(reader.GetOrdinal("fld_status"))),
                                    customer_DateTime = (reader.GetString(reader.GetOrdinal("fld_datetime"))),
                                    customer_Profile = (reader.GetString(reader.GetOrdinal("fld_profile"))),
                                    customer_DOB = (reader.GetString(reader.GetOrdinal("fld_dob"))),
                                    customer_TimeZone = (reader.GetString(reader.GetOrdinal("fld_timezone"))),
                                    customer_Phnnumber = (reader.GetString(reader.GetOrdinal("fld_phn_number"))),
                                    customer_Gender = (reader.GetString(reader.GetOrdinal("fld_gender")))

                                });

                            }
                            sqlConnection.Close();
                            loginResponseDetailsModel.loginRequestResponses = loginRequestResponses;
                        }


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