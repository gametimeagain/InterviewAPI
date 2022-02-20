using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterviewAPI.Controllers {
    public class DateController : ApiController {
        // GET api/date/dayOfWeek
        public HttpResponseMessage Get(string requestedDayOfWeek) {
            try {
                //  We will base the method on Utc
                DateTime today = DateTime.UtcNow;

                //  Get the difference between today and the day of week requested
                int differenceFromToday = (int)today.DayOfWeek - (int)Enum.Parse(typeof(DayOfWeek), requestedDayOfWeek);
                
                //  Grab the next matching day by moving forward or backwards as needed  
                string nextMatchingDay = today.AddDays(differenceFromToday < 0 ? differenceFromToday * -1 : 7 - differenceFromToday).ToString("dd-MMM-yyyy");

                //  No errors?  Return the result
                return Request.CreateResponse(HttpStatusCode.OK, nextMatchingDay);
            } catch {
                //  TODO: Provide better handling and messages
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}