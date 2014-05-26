using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using LRDNUG_V2.Models;

namespace LRDNUG_V2.Controllers
{
    public class MeetingsController : ApiController
    {
        private lrdnugweb db = new lrdnugweb();

        // GET: api/Meetings
        public IEnumerable<Meeting> Get()
        {
            return db.Meetings.ToList();
        }

        // GET: api/Meetings/5
        public Meeting Get(int id)
        {
            return db.Meetings.Where(m => m.ID == id).FirstOrDefault();
        }
    }
}
