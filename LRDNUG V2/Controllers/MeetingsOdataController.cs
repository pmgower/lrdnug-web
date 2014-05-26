using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using LRDNUG_V2.Models;

namespace LRDNUG_V2.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using LRDNUG_V2.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Meeting>("MeetingsOdata");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MeetingsOdataController : ODataController
    {
        private lrdnugweb db = new lrdnugweb();

        // GET: odata/MeetingsOdata
        [Queryable]
        public IQueryable<Meeting> GetMeetingsOdata()
        {
            return db.Meetings;
        }

        // GET: odata/MeetingsOdata(5)
        [Queryable]
        public SingleResult<Meeting> GetMeeting([FromODataUri] int key)
        {
            return SingleResult.Create(db.Meetings.Where(meeting => meeting.ID == key));
        }

        // PUT: odata/MeetingsOdata(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != meeting.ID)
            {
                return BadRequest();
            }

            db.Entry(meeting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(meeting);
        }

        // POST: odata/MeetingsOdata
        public async Task<IHttpActionResult> Post(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Meetings.Add(meeting);
            await db.SaveChangesAsync();

            return Created(meeting);
        }

        // PATCH: odata/MeetingsOdata(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Meeting> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Meeting meeting = await db.Meetings.FindAsync(key);
            if (meeting == null)
            {
                return NotFound();
            }

            patch.Patch(meeting);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(meeting);
        }

        // DELETE: odata/MeetingsOdata(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Meeting meeting = await db.Meetings.FindAsync(key);
            if (meeting == null)
            {
                return NotFound();
            }

            db.Meetings.Remove(meeting);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeetingExists(int key)
        {
            return db.Meetings.Count(e => e.ID == key) > 0;
        }
    }
}
