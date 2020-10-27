using LeadTracker.Models;
using LeadTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeadTrackerBKM.Controllers
{
    [Authorize]
    public class RepController : ApiController
    {
       
       RepService repService = new RepService();//NoteService(userId);
            
        public IHttpActionResult Get()
        {
            var reps = repService.GetReps();
            return Ok(reps);
        }
        public IHttpActionResult Post(RepCreate rep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!repService.CreateLead(rep))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            var rep = repService.GetRepByID(id);
            return Ok(rep);
        }
        public IHttpActionResult Put(RepDetail rep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!repService.UpdateRep(rep))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {

            if (!repService.DeleteRep(id))
                return InternalServerError();

            return Ok();
        }
    }
}
