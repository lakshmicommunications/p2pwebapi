using MySql.Data.MySqlClient;
using p2p_web_api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2p_web_api.Connector
{
    public class BookingRepository
    {

        private string connectstring;
        public BookingRepository()
        {
            connectstring = @"server=p2pmaindb.crjqjvqsqaox.ca-central-1.rds.amazonaws.com;username=admin;password=m3Dicine2020!;database=p2pmedicaldb";
        }

        public List<BookingAppointmentDetailsResponse> bookingAppointmentDetails()
        {
            BookingAppointmentResponseModel responseModel = new BookingAppointmentResponseModel();
            List<BookingAppointmentDetailsResponse> bookingAppointmentDetails = new List<BookingAppointmentDetailsResponse>();
            using (MySqlConnection sqlConnection = new MySqlConnection(connectstring))
            {
                using (MySqlCommand mySqlCommand = sqlConnection.CreateCommand())
                {
                    try
                    {
                        mySqlCommand.CommandText = "SELECT *FROM tbl_book_appoinment WHERE fld_confirm=1 AND fld_booked_status=1";
                        mySqlCommand.CommandType = System.Data.CommandType.Text;
                        mySqlCommand.Connection = sqlConnection;
                        sqlConnection.Open();
                        using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookingAppointmentDetails.Add(new BookingAppointmentDetailsResponse
                                {
                                    booking_ID=reader.GetString(reader.GetOrdinal("fld_id")),
                                    customer_ID = reader.GetString(reader.GetOrdinal("fld_customer_id")),
                                    provider_ID = reader.GetString(reader.GetOrdinal("fld_provider_id")),
                                    booking_status = reader.GetString(reader.GetOrdinal("fld_booked_status")),
                                    call_duration = reader.GetString(reader.GetOrdinal("fld_call_duration")),
                                    booking_Datetime = reader.GetString(reader.GetOrdinal("fld_datetime")),
                                    custmer_message = reader.GetString(reader.GetOrdinal("fld_customer_message")),
                                    appointment_type = reader.GetString(reader.GetOrdinal("fld_appointment_type")),
                                    appointment_confirm_status = reader.GetString(reader.GetOrdinal("fld_confirm")),
                                    appointment_archive = reader.GetString(reader.GetOrdinal("fld_archive")),
                                    provider_archive = reader.GetString(reader.GetOrdinal("fld_provider_archive")),
                                    room_in = reader.GetString(reader.GetOrdinal("fld_room_in")),
                                    app_time_slot = reader.GetString(reader.GetOrdinal("fld_app_time_slot")),
                                    random_id = reader.GetString(reader.GetOrdinal("fld_random_id")),
                                });
                            }
                        }

                    }
                    catch(Exception e)
                    {
                        responseModel.Messaage = e.Message.ToString();

                    }
                }
            }
            return bookingAppointmentDetails;
        }
    }
}