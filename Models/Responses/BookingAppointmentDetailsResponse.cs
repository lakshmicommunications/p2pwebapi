using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2p_web_api.Models.Responses
{
    public class BookingAppointmentDetailsResponse
    {
        public string booking_ID { get; set; }
        public string customer_ID { get; set; }
        public string provider_ID { get; set; }
        public string schedule_ID { get; set; }
        public string booking_status { get; set; }
        public string booking_Datetime { get; set; }
        public string custmer_message { get; set; }
        public string appointment_type { get; set; }
        public string appointment_confirm_status { get; set; }
        public string appointment_archive { get; set; }
        public string provider_archive { get; set; }
        public string room_in { get; set; }
        public string app_time_slot { get; set; }
        public string call_duration { get; set; }
        public string random_id { get; set; }
        
    }
}