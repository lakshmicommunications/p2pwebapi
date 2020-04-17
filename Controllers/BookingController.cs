using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using p2p_web_api.Models.Responses;
using p2p_web_api.Connector;

namespace p2p_web_api.Controllers
{
    public class BookingController : ApiController
    {
        [HttpGet]
        public BookingAppointmentResponseModel bookingAppointment()
        {
            BookingAppointmentResponseModel responseModel = new BookingAppointmentResponseModel();
            List<BookingAppointmentDetailsResponse> bookingAppointmentDetails = new List<BookingAppointmentDetailsResponse>();
            BookingRepository bookingRepository = new BookingRepository();
            responseModel.bookingAppointmentDetails = bookingRepository.bookingAppointmentDetails();
            bookingAppointmentDetails= bookingRepository.bookingAppointmentDetails();
            if (bookingAppointmentDetails.Count <= 0)
            {
                responseModel.Messaage = "No data found";
                responseModel.responseCode = "200";
            }
            else
            {
                responseModel.Messaage = "Appointment Details";
                responseModel.responseCode = "200";
            }
            return responseModel;
        }
    }
}
