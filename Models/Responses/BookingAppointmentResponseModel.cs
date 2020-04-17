using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2p_web_api.Models.Responses
{
    public class BookingAppointmentResponseModel
    {
        public string responseCode { get; set; }
        public string Messaage { get; set; }
        public List<BookingAppointmentDetailsResponse>bookingAppointmentDetails { get; set; }
    }
}