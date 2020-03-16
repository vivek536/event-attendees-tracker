using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Event_Attendees_Tracker_BAL.User_Actions;
namespace Event_Attendees_Tracker_API.Controllers
{
    public class EventController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage PastEvents(int userId)
        {
            try
            {
                String Jsondata = FetchPastEvents.fetchPastEventData(userId);
                if (Jsondata != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, Jsondata);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "No Data Found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}
